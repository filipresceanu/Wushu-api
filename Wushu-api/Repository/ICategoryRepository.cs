using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface ICategoryRepository
    {
        Task CreateCategory(CategoryDto categorydto);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesDto();

        Task<IEnumerable<Category>> GetAllCategories();

        Task AddParticipantInCategory(Participant participant);

        Task<Category> GetCategory(Guid categoryId);
        Task DeleteCategory(Guid categoryId);

        Task EditCategory(Guid categoryId);


        //TODO edit category
        //TODO delete category
    }
}
