using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class SurowceDlaEtapuProfile : Profile
    {
        public SurowceDlaEtapuProfile()
        { 
            CreateMap<SurowceDlaEtapuCreationDto, SurowceDlaEtapuDto>();
            CreateMap<SurowceDlaEtapuUpdateDto, SurowceDlaEtapuDto>();
            CreateMap<SurowceDlaEtapuDto, SurowceDlaEtapuUpdateDto>();
        }
    }
}
