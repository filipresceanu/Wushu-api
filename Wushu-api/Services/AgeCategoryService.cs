using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class AgeCategoryService : IAgeCategoryService
    {
        private readonly IAgeCategoryRepository _ageCategoryRepository;
        private readonly IEventRepository _eventRepository;
        public AgeCategoryService(IAgeCategoryRepository ageCategoryRepository, IEventRepository eventRepository)
        {
            _ageCategoryRepository = ageCategoryRepository;
            _eventRepository = eventRepository;
        }

        public async Task CreateAgeCategory(AgeCategoryDto ageCategory)
        {
            await _ageCategoryRepository.CreateAgeCategory(ageCategory);
        }

        public async Task<AgeCategory> GetAgeCategoryById(Guid ageCategoryId)
        {
            var ageCategory= await _ageCategoryRepository.GetAgeCategoryById(ageCategoryId);
            return ageCategory;
        }

        public async Task<IEnumerable<AgeCategoryDto>> GetAgeCategories()
        {
            var ageCategories=await _ageCategoryRepository.GetAgeCategories();  
            return ageCategories;
        }
    }
}
