using AutoMapper;
using BusinessObjects;
using DTOs.Request.Authentication;
using DTOs.Request.BadmintonCourt;
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
            BadmintonCourtMappingProfile();
            AuthenticationMappingProfile();
        }

        private void BadmintonCourtMappingProfile()
        {
            CreateMap<CreateBadmintonCourtRequest, BadmintonCourtEntity>();
            CreateMap<BadmintonCourtEntity, BadmintonCourtDto>();
        }

        private void AuthenticationMappingProfile()
        {
            CreateMap<RegisterRequest, UserEntity>();
            CreateMap<UserEntity, RegisterResponse>();

        }

    }
}
