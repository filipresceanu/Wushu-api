using System.Collections.Generic;
using WushuParticipants.Dto;
using WushuParticipants.Models;

namespace WushuParticipants.Repository
{
    public interface IAgeCategoryRepository
    {
        Task CreateAgeCategory(AgeCategoryDto ageCategory);

        Task<AgeCategory> GetAgeCategoryById(Guid ageCategoryId);

        Task<IEnumerable<AgeCategoryDto>> GetAgeCategories();
    }
}
