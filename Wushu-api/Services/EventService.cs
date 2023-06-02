using AutoMapper;
using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class EventService:IEventService
    {
        private IEventRepository _eventRepository;
        private IMapper _mapper;

        public EventService(IEventRepository eventRepository,IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task CreateEvent(Event competiton)
        {
           await _eventRepository.CreateEvent(competiton);
        }

      
        public async Task<IEnumerable<EventDto>> GetEvents()
        {
            var events= await _eventRepository.GetAllEvents();
            return events;
        }
    }
}
