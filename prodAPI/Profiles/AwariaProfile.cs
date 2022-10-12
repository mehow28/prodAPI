using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class AwariaProfile : Profile
    {
        public AwariaProfile()
        {
            CreateMap<AwariaCreationDto, AwariaDto>();
            CreateMap<AwariaUpdateDto, AwariaDto>();
            CreateMap<AwariaDto,AwariaUpdateDto>();
        }
    }
}
