using System.Collections.Generic;
using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IAgeCategoryRepository
    {
        Task CreateAgeCategory(AgeCategoryDto ageCategory);

        Task<AgeCategory> GetAgeCategoryById(Guid ageCategoryId);

        Task<IEnumerable<AgeCategoryDto>> GetAgeCategories();
    }
}
