using BusinessObjects;
using BusinessObjects.Constants;
using DTOs;
using DTOs.Request.TypeOfCourt;
using DTOs.Response.BadmintonCourt;
using DTOs.Response.TypeOfCourt;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class TypeOfCourtDAO
    {
        private readonly AppDbContext _context;
        private static TypeOfCourtDAO instance;

        public TypeOfCourtDAO()
        {
            _context = new AppDbContext();
        }

        public static TypeOfCourtDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TypeOfCourtDAO();
                }
                return instance;
            }
        }

        public async Task<Result<TypeOfCourtDto>> Create(TypeOfCourtRequest request)
        {
            try
            {
                TypeOfCourtEntity entity = request.Adapt<TypeOfCourtEntity>();

                await _context.TypeOfCourts.AddAsync(entity);
                bool isSuccessful = await _context.SaveChangesAsync() > 0;

                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.TypeOfCourt.Fail.CreateTypeOfCourt);
                }

                return new Result<TypeOfCourtDto>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = entity.Adapt<TypeOfCourtDto>(),
                };

            } catch (Exception ex)
            {
                return new Result<TypeOfCourtDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                };
            }
        }
    }
}
