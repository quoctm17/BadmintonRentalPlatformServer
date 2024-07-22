using System.Net;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using Services.Interface;

namespace BadmintonRentalPlatformAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PayOS _payOs;
    private readonly IConfiguration _configuration;
    private readonly IBookingReservationService _bookingReservationService;

    public PaymentController(IConfiguration configuration, IBookingReservationService bookingReservationService)
    {
        _configuration = configuration;
        _bookingReservationService = bookingReservationService;
        _payOs = new PayOS(_configuration.GetSection("PayOS:ClientID").Value!,
            _configuration.GetSection("PayOS:ApiKey").Value!,
            _configuration.GetSection("PayOS:ChecksumKey").Value!);
    }

    [HttpGet("payment")]
    public async Task<IActionResult> CreatePaymentLink(int bookingId)
    {
        var booking = await _bookingReservationService.GetDetail(bookingId);
        ItemData item = new ItemData("Thanh toán đặt sân cầu lông", 1, (int) booking.Data!.TotalPrice);
        List<ItemData> items = new List<ItemData>()
        {
            item
        };
        PaymentData paymentData = new PaymentData(booking.Data!.Id, (int) booking.Data!.TotalPrice,
            "Thanh toán đặt lịch",
            items, "https://localhost:5135/", "https://localhost:5135/");
        CreatePaymentResult createPaymentResult = await _payOs.createPaymentLink(paymentData);
        return Ok(new Result<CreatePaymentResult>()
        {
            StatusCode = HttpStatusCode.OK,
            Data = createPaymentResult
        });
    }
}