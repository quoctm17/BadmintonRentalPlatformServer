using DataAccessObject;
using DTOs.Request.BookingReservation;
using DTOs;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<Result<bool>> Create(CreateBookingReservationRequest request) => _repository.Create(request);
        public Task<Result<bool>> Delete(int id) => _repository.Delete(id);
        public Task<Result<ICollection<BookingReservationViewModel>>> GetAll() => _repository.GetAll();
        public Task<Result<bool>> Update(int id, UpdateBookingReservationRequest request) => _repository.Update(id, request);
    }
}
