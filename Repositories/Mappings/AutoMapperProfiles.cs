using AutoMapper;
using BusinessObjects;
using DTOs.Request.AuthenPlayer;
using DTOs.Request.Authentication;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.AuthenPlayer;
using DTOs.Response.Authentication;
using DTOs.Response.BadmintonCourt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateBadmintonCourtRequest, BadmintonCourtEntity>();
            CreateMap<BadmintonCourtEntity, BadmintonCourtDto>();

            CreateMap<RegisterRequest, UserEntity>();
            CreateMap<UserEntity, RegisterResponse>();

            CreateMap<PlayerRegisterRequest, UserEntity>();
            CreateMap<UserEntity, PlayerRegisterResponse>();
        }

    }
}
