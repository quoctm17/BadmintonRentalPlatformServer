﻿using DTOs;
using DTOs.Request.BookingReservation;
using DTOs.Response.BookingReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface IBookingReservationRepository
    {
        Task<Result<int>> Create(CreateBookingReservationRequest request);
        Task<Result<bool>> Delete(int id);
        Task<Result<ICollection<BookingReservationViewModel>>> GetAll();
        Task<Result<bool>> Update(int id, UpdateBookingReservationRequest request);
        public Task<Result<List<BookingDetailEntity>>> GetAllBookingDetails();
        public Task<Result<BookingReservationEntity?>> GetDetailOfBookingReservation(int bookingId);
        public Task<Result<List<BookingReservationEntity>>> GetAllBookingOfUser(int userId);
        Task<Result<bool>> CancelBooking(int bookingId);
        Task<Result<bool>> UpdatePaymentLinkId(int bookingId, string paymentLinkId);
        Task<Result<BookingReservationEntity?>> GetDetailByOrderCode(long orderCode);
        Task<Result<bool>> UpdateTransactionStatus(int bookingId, string status);
        Task<Result<bool>> UpdateBookingStatus(int bookingId, string status);
        Task<Result<BookingReservationEntity?>> GetDetailByPaymentLinkId(string paymentLinkId);


    }

}
