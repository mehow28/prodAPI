using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class EtapyProfile : Profile
    {
        public EtapyProfile()
        { 
            CreateMap<EtapyCreationDto, EtapyDto>();
            CreateMap<EtapyUpdateDto, EtapyDto>();
            CreateMap<EtapyDto, EtapyUpdateDto>();
        }
    }
}
