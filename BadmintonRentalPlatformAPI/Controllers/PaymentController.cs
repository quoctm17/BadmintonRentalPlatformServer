using System.Net;
using BusinessObjects.Constants;
using BusinessObjects;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using Services.Interface;
using BusinessObjects.Enums;
using Services;
using BusinessObjects.Helpers;

namespace BadmintonRentalPlatformAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PayOS _payOs;
    private readonly IConfiguration _configuration;
    private readonly IBookingReservationService _bookingReservationService;
    private readonly ITransactionService _transactionService;
    private readonly IPaymentService _service;

    public PaymentController(IConfiguration configuration, IBookingReservationService bookingReservationService, IPaymentService service, ITransactionService transactionService)
    {
        _configuration = configuration;
        _bookingReservationService = bookingReservationService;
        _payOs = new PayOS(_configuration.GetSection("PayOS:ClientID").Value!,
            _configuration.GetSection("PayOS:ApiKey").Value!,
            _configuration.GetSection("PayOS:ChecksumKey").Value!);
        _service = service;
        _transactionService = transactionService;
    }

    [HttpGet("payment")]
    public async Task<IActionResult> CreatePaymentLink(int bookingId)
    {
        var booking = await _bookingReservationService.GetDetail(bookingId);
        if (booking == null || booking.Data == null)
        {
            return NotFound(new Result<string>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "BookingReservation not found",
                Data = null
            });
        }

        long uniqueOrderCode = long.Parse($"{booking.Data.CreateAt:yyyyMMddHHmmss}{booking.Data.Id}");

        ItemData item = new ItemData("Thanh toán đặt sân cầu lông", 1, (int)booking.Data.TotalPrice);
        List<ItemData> items = new List<ItemData> { item };

        PaymentData paymentData = new PaymentData(uniqueOrderCode, (int)booking.Data.TotalPrice,
            "Thanh toán đặt lịch", items, "https://localhost:5135/index", "https://localhost:5135/index");

        CreatePaymentResult createPaymentResult = await _payOs.createPaymentLink(paymentData);

        if (createPaymentResult != null)
        {
            var updateResult = await _bookingReservationService.UpdatePaymentLinkId(bookingId, createPaymentResult.paymentLinkId);
            if (updateResult.StatusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)updateResult.StatusCode, updateResult.Message);
            }
        }

        return Ok(new Result<CreatePaymentResult>
        {
            StatusCode = HttpStatusCode.OK,
            Data = createPaymentResult
        });
    }

    [HttpPost("update-payment-status")]
    public async Task<IActionResult> UpdatePaymentStatus([FromQuery] string paymentLinkId, [FromQuery] string status)
    {
        try
        {
            var bookingReservation = await _bookingReservationService.GetDetailByPaymentLinkId(paymentLinkId);
            if (bookingReservation == null || bookingReservation.Data == null)
            {
                return NotFound(new Result<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Booking reservation not found",
                    Data = null
                });
            }

            if (status == "PAID")
            {
                var transactionUpdateResult = await _transactionService.UpdateTransactionStatus(bookingReservation.Data.Id, TransactionStatusEnum.COMPLETE.GetDescriptionFromEnum());
                if (transactionUpdateResult.StatusCode != HttpStatusCode.OK)
                {
                    return StatusCode((int)transactionUpdateResult.StatusCode, new { message = transactionUpdateResult.Message });
                }

                var bookingUpdateResult = await _bookingReservationService.UpdateBookingStatus(bookingReservation.Data.Id, BookingStatusEnum.BOOKED.GetDescriptionFromEnum());
                if (bookingUpdateResult.StatusCode != HttpStatusCode.OK)
                {
                    return StatusCode((int)bookingUpdateResult.StatusCode, new { message = bookingUpdateResult.Message });
                }
            }
            else if (status == "CANCELLED")
            {
                var transactionUpdateResult = await _transactionService.UpdateTransactionStatus(bookingReservation.Data.Id, TransactionStatusEnum.FAIL.GetDescriptionFromEnum());
                if (transactionUpdateResult.StatusCode != HttpStatusCode.OK)
                {
                    return StatusCode((int)transactionUpdateResult.StatusCode, new { message = transactionUpdateResult.Message });
                }

                var bookingUpdateResult = await _bookingReservationService.UpdateBookingStatus(bookingReservation.Data.Id, BookingStatusEnum.CANCELLED.GetDescriptionFromEnum());
                if (bookingUpdateResult.StatusCode != HttpStatusCode.OK)
                {
                    return StatusCode((int)bookingUpdateResult.StatusCode, new { message = bookingUpdateResult.Message });
                }

                try
                {
                    await _payOs.cancelPaymentLink(long.Parse(paymentLinkId));
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
                }
            }

            return Ok(new Result<bool>
            {
                StatusCode = HttpStatusCode.OK,
                Data = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
        }
    }


    [HttpGet(ApiEndPointConstant.Payment.PaymentsEndpoint)]
    [ProducesResponseType(typeof(Result<ICollection<PaymentEntity>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        Result<ICollection<PaymentEntity>> result = await _service.GetAll();
        return StatusCode((int)result.StatusCode, result);
    }
}