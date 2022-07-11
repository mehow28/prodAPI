using AutoMapper;
namespace prodAPI.Profiles
{
    public class EtapyProfile : Profile
    {
        public EtapyProfile()
        {
            CreateMap<Entities.Etapy, Models.EtapyDto>();
        }
    }
}
