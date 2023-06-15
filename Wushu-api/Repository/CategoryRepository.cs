using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Wushu_api.Data;
using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CategoryRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public Task AddParticipantInCategory(Participant participant)
        {
            throw new NotImplementedException();
        }

        public async Task CreateCategory(CategoryDto categorydto)
        {
            var category = _mapper.Map<Category>(categorydto);
            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _dataContext.Categories.ToListAsync();
            return await categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesDto()
        {
            var categoris = _dataContext.Categories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).ToListAsync();
            return await categoris;
        }
    }
}
