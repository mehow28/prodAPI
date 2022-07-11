using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class ZleceniumProfile : Profile
    {
        public ZleceniumProfile()
        {
            CreateMap<ZleceniumCreationDto,ZleceniumDto>();
            CreateMap<ZleceniumUpdateDto, ZleceniumDto>();
            CreateMap<ZleceniumDto,ZleceniumUpdateDto>();
        }
    }
}
