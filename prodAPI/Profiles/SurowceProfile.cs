using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class SurowceProfile : Profile
    {
        public SurowceProfile()
        {
            CreateMap<SurowceCreationDto,SurowceDto>();
            CreateMap<SurowceUpdateDto, SurowceDto>();
            CreateMap<SurowceDto,SurowceUpdateDto>();
        }
    }
}
