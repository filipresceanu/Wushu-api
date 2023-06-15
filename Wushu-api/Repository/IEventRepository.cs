using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IEventRepository
    {
        Task CreateEvent(Event competition);

        Task DeleteEvent(Event competition);

        Task<Event> GetEventId(Guid  eventId);

        Task<IEnumerable<EventDto>> GetAllEvents();

        //TODO edit event


    }
}
