using AutoMapper;
using prodAPI.Models;

namespace prodAPI.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<StatusCreationDto,StatusDto>();
            CreateMap<StatusUpdateDto, StatusDto>();
            CreateMap<StatusDto,StatusUpdateDto>();
        }
    }
}
