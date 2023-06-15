using AutoMapper;
using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<Participant, ParticipantDto>();
            CreateMap<ParticipantDto, Participant>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
