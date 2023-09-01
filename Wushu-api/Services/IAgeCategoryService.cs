using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface IAgeCategoryService
    {
        Task CreateAgeCategory(AgeCategoryDto ageCategory);

        Task<AgeCategory> GetAgeCategoryById(Guid ageCategoryId);

        Task<IEnumerable<AgeCategoryDto>> GetAgeCategories();
    }
}
