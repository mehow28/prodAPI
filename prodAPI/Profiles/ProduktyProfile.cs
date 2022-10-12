using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class ProduktyProfile : Profile
    {
        public ProduktyProfile()
        {
            CreateMap<ProduktyCreationDto, ProduktyDto>();
            CreateMap<ProduktyUpdateDto, ProduktyDto>();
            CreateMap<SurowceDto,SurowceDto>();
        }
    }
}
