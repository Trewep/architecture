using AutoMapper;
using OurProject.API.Controllers;
using OurProject.API.Models;

namespace OurProject.API.Profiles
{
    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<User, EventOrgReadDto>();
            CreateMap<Event, EventOrgReadDto>();
            CreateMap<User, EventOrgCreateDto>();
            CreateMap<Event, EventOrgCreateDto>();
        }
    }
}