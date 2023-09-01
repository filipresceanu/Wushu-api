using AutoMapper;
using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IAgeCategoryRepository _ageCategoryRepository;     
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IEventRepository eventRepository, IMapper mapper, IAgeCategoryRepository ageCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
            _ageCategoryRepository = ageCategoryRepository;
        }

        public  async Task CreateCategory(CategoryDto categoryDto,
            Guid eventId,Guid categoryAgeId)
        {
            var eventCategory=await _eventRepository.GetEventId(eventId);
            var ageCategory=await _ageCategoryRepository.GetAgeCategoryById(categoryAgeId);
            var category = _mapper.Map<Category>(categoryDto);
            category.Event = eventCategory;
            category.AgeCategory = ageCategory;
            await _categoryRepository.CreateCategory(category);
        }

        public async Task DeleteCategory(Guid categoryId)
        {
             await _categoryRepository.DeleteCategory(categoryId);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesDto()
        {
            return await _categoryRepository.GetAllCategoriesDto();
        }

        public async Task<IEnumerable<CategoryDataDto>> GetCategoryData(Guid eventId)
        {
            var categories=await _categoryRepository.GetCategorieForEventId(eventId);
            List<CategoryDataDto> data = new List<CategoryDataDto>();
            foreach(var category in categories)
            {
                CategoryDataDto categoryDataDto = new CategoryDataDto();
                var ageCategoryId = category.AgeCategoryId;
                var ageCategory = await _ageCategoryRepository.GetAgeCategoryById(ageCategoryId);
                categoryDataDto.Name=ageCategory.Name;
                categoryDataDto.LessThanAge= ageCategory.LessThanAge;
                categoryDataDto.GraterThanAge= ageCategory.GraterThanAge;
                categoryDataDto.LessThanWeight=category.LessThanWeight;
                categoryDataDto.Sex=category.Sex;
                categoryDataDto.GraterThanWeight = category.GraterThanWeight;
                data.Add(categoryDataDto);
            }
            return data;
        }
    }
}
