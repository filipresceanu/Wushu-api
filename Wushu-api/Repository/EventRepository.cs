using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Wushu_api.Data;
using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public class EventRepository:IEventRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EventRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper= mapper;
        }

      

        public async Task CreateEvent(Event competition)
        {
            _dataContext.Events.Add(competition);
            await _dataContext.SaveChangesAsync();
        }

        public Task DeleteEvent(Event competition)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventDto>> GetAllEvents()
        {
            var events= _dataContext.Events.ProjectTo<EventDto>
                (_mapper.ConfigurationProvider).ToListAsync();           
            return await events;
        }

        public async Task<Event> GetEventId(Guid eventId)
        {
            var competition=await _dataContext.Events.SingleOrDefaultAsync(element=>element.Id==eventId);
            return  competition;
        }

      
    }
}
