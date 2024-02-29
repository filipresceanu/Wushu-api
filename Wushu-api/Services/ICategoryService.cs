using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryDto categoryDto,Guid competitionId,Guid categoryAgeId);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesDto();

        Task DeleteCategory(Guid categoryId);

        Task<IEnumerable<CategoryDataDto>> GetCategoryData(Guid competitionId);

        Task<IEnumerable<CategoryDto>> GetCategoriesForCompetitionId(Guid competitionId);
    }
}
