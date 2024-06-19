using AutoMapper;
using BusinessObjects;
using DTOs.Request.BadmintonCourt;
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
            CreateMap<BadmintonCourtEntity, CreateBadmintonCourtRequest>().ReverseMap();
            CreateMap<BadmintonCourtEntity, BadmintonCourtDto>().ReverseMap();
        }

    }
}
