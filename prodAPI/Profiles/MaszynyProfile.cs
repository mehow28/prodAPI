
using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class MaszynyProfile : Profile
    {
        public MaszynyProfile()
        {
            CreateMap<MaszynyCreationDto,MaszynyDto>();
            CreateMap<MaszynyUpdateDto, MaszynyDto>();
            CreateMap<MaszynyDto,MaszynyUpdateDto>();
        }
    }
}
