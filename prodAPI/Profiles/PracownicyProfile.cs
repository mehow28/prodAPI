using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class PracownicyProfile : Profile
    {
        public PracownicyProfile()
        {
            CreateMap<PracownicyCreationDto,PracownicyDto>();
            CreateMap<PracownicyUpdateDto, PracownicyDto>();
            CreateMap<PracownicyDto,PracownicyUpdateDto>();
        }
    }
}
