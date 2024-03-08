using AutoMapper;
using WushuParticipants.Dto;
using WushuParticipants.Models;

namespace WushuParticipants.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Competition, CompetitionDto>();
            CreateMap<Participant, ParticipantDto>();
            CreateMap<ParticipantDto, Participant>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<AgeCategoryDto, AgeCategory>();
            CreateMap<AgeCategory,AgeCategoryDto>();
        }
    }
}
