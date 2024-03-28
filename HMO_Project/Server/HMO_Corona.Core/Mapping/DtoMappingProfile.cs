using AutoMapper;
using HMO_Corona.Core.Dtos;
using HMO_Corona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Corona.Core.Mapping
{
    public class DtoMappingProfile:Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<CoronaDetails, CoronaDetailsDto>();
            CreateMap<PersonalDetails, PersonalDetailsDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom((src, dest, destPersonalDetails, context) =>
            {
                if (src.FileData is null)
                {
                    return null;
                }
                var url = context.Items["Url"];
                var fullUrl = url + "" + src.Id + "/Image";
                return fullUrl;
            }));
        }
    }
}
