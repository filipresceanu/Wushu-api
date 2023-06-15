using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _placeOfCompetitionRepository;

        public CategoryService(ICategoryRepository placeOfCompetitionRepository)
        {
            _placeOfCompetitionRepository = placeOfCompetitionRepository;
        }

        public  async Task CreateCategory(CategoryDto categoryDto)
        {
           await _placeOfCompetitionRepository.CreateCategory(categoryDto);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesDto()
        {
            return await _placeOfCompetitionRepository.GetAllCategoriesDto();
        }
    }
}
