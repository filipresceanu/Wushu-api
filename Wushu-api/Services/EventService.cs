using AutoMapper;
using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class EventService:IEventService
    {
        private IEventRepository _eventRepository;
       

        public EventService(IEventRepository eventRepository,IMapper mapper)
        {
            _eventRepository = eventRepository;
            
        }

        public async Task CreateEvent(Event competiton)
        {
           await _eventRepository.CreateEvent(competiton);
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var element= await _eventRepository.GetEventId(id);
            return element;
        }

        public async Task<IEnumerable<EventDto>> GetEvents()
        {
            var events= await _eventRepository.GetAllEvents();
            return events;
        }
    }
}
