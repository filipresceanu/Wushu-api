using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryDto category);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesDto();

        Task DeleteCategory(Guid categoryId);
    }
}
