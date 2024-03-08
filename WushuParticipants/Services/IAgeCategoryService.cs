using WushuParticipants.Dto;
using WushuParticipants.Models;

namespace WushuParticipants.Services
{
    public interface IAgeCategoryService
    {
        Task CreateAgeCategory(AgeCategoryDto ageCategory);

        Task<AgeCategory> GetAgeCategoryById(Guid ageCategoryId);

        Task<IEnumerable<AgeCategoryDto>> GetAgeCategories();
    }
}
