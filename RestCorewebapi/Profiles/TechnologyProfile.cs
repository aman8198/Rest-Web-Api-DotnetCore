using AutoMapper;
using RestCorewebapi.DTOS;
using RestCorewebapi.Models;

namespace RestCorewebapi.Profiles
{
    public class TechnologyProfile : Profile
    {
        public TechnologyProfile()
        {
            CreateMap<TechnologyProfile, TechnologyReadDto>();
            CreateMap<TechnologyCreateDto, technologies>();
            CreateMap<TechnologyUpdateDto, technologies>();
            CreateMap<technologies, TechnologyUpdateDto>();
            
        }

    }
}