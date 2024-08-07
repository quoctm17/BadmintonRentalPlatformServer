﻿using DataAccessObject;
using DTOs.Request.BookingReservation;
using DTOs;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DTOs.Response.BookingReservation;
using Microsoft.Extensions.Logging;
using Repositories.Interface;

namespace Services
{
    public class BookingReservationService : IBookingReservationService
    {
        private readonly IBookingReservationRepository _repository;
        public BookingReservationService(IBookingReservationRepository repository)
        {
            _repository = repository;
        }

        public Task<Result<int>> Create(CreateBookingReservationRequest request) => _repository.Create(request);
        public Task<Result<bool>> Delete(int id) => _repository.Delete(id);
        public Task<Result<ICollection<BookingReservationViewModel>>> GetAll() => _repository.GetAll();
        public Task<Result<bool>> Update(int id, UpdateBookingReservationRequest request) => _repository.Update(id, request);
        public async Task<Result<List<BookingDetailEntity>>> GetAllBookingDetails()
        {
            return await _repository.GetAllBookingDetails();
        }

        public async Task<Result<BookingReservationEntity?>> GetDetail(int bookingId)
        {
            return await _repository.GetDetailOfBookingReservation(bookingId);
        }

        public async Task<Result<List<BookingReservationEntity>>> GetAllBookingReservationOfUser(int userId)
        {
            return await _repository.GetAllBookingOfUser(userId);
        }
        public async Task<Result<bool>> CancelBooking(int bookingId)
        {
            return await _repository.CancelBooking(bookingId);
        }

        public async Task<Result<bool>> UpdatePaymentLinkId(int bookingId, string paymentLinkId)
        {
            return await _repository.UpdatePaymentLinkId(bookingId, paymentLinkId);
        }

        public async Task<Result<BookingReservationEntity?>> GetDetailByOrderCode(long orderCode)
        {
            return await _repository.GetDetailByOrderCode(orderCode);
        }

        public async Task<Result<bool>> UpdateTransactionStatus(int bookingId, string status)
        {
            return await _repository.UpdateTransactionStatus(bookingId, status);
        }

        public async Task<Result<bool>> UpdateBookingStatus(int bookingId, string status)
        {
            return await _repository.UpdateBookingStatus(bookingId, status);
        }
        public async Task<Result<BookingReservationEntity?>> GetDetailByPaymentLinkId(string paymentLinkId)
        {
            return await _repository.GetDetailByPaymentLinkId(paymentLinkId);
        }

    }
}
