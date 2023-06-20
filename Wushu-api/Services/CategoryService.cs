using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public  async Task CreateCategory(CategoryDto categoryDto)
        {
           await _categoryRepository.CreateCategory(categoryDto);
        }

        public async Task DeleteCategory(Guid categoryId)
        {
             await _categoryRepository.DeleteCategory(categoryId);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesDto()
        {
            return await _categoryRepository.GetAllCategoriesDto();
        }
    }
}
