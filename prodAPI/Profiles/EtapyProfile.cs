using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class ProduktyDlaEtapuProfile : Profile
    {
        public ProduktyDlaEtapuProfile()
        { 
            CreateMap<ProduktyDlaEtapuCreationDto, ProduktyDlaEtapuDto>();
            CreateMap<EtapyUpdateDto, ProduktyDlaEtapuDto>();
            CreateMap<ProduktyDlaEtapuDto, ProduktyDlaEtapuUpdateDto>();
        }
    }
}
