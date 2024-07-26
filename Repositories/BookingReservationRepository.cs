using Azure.Core;
using DataAccessObject;
using DTOs;
using DTOs.Request.BookingReservation;
using DTOs.Response.BookingReservation;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public class BookingReservationRepository : IBookingReservationRepository
    {


        public async Task<Result<bool>> Create(CreateBookingReservationRequest request) => await BookingReservationDAO.Instance.Create(request);
        public async Task<Result<bool>> Delete(int id) => await BookingReservationDAO.Instance.Delete(id);
        public async Task<Result<ICollection<BookingReservationViewModel>>> GetAll() => await BookingReservationDAO.Instance.GetAll();
        public async Task<Result<bool>> Update(int id, UpdateBookingReservationRequest request) => await BookingReservationDAO.Instance.Update(id, request);
        public async Task<Result<List<BookingDetailEntity>>> GetAllBookingDetails()
        {
            return new Result<List<BookingDetailEntity>>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await BookingDetailDAO.Instance.GetAllBookingDetails()
            };
        }

        public async Task<Result<BookingReservationEntity?>> GetDetailOfBookingReservation(int bookingId)
        {
            return new Result<BookingReservationEntity?>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await BookingReservationDAO.Instance.GetDetail(bookingId)
            };
        }

        public async Task<Result<List<BookingReservationEntity>>> GetAllBookingOfUser(int userId)
        {
            return new Result<List<BookingReservationEntity>>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await BookingReservationDAO.Instance.GetAllBookingReservationOfUser(userId)
            };
        }
        public async Task<Result<bool>> CancelBooking(int bookingId)
        {
            return await BookingReservationDAO.Instance.CancelBooking(bookingId);
        }
    }
}
