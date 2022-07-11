using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class KontumProfile : Profile
    {
        public KontumProfile()
        {
            CreateMap<KontumCreationDto, KontumDto>();
            CreateMap<KontumUpdateDto, KontumDto>();
            CreateMap<KontumDto, KontumUpdateDto>();
        }
    }
}
