using AutoMapper;
using HMO_Corona.API.Models;
using HMO_Corona.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMO_Corona.API.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<PersonalDetailsModel, PersonalDetails>();
            CreateMap<CoronaDetailsModel, CoronaDetails>();
        }
    }
}
