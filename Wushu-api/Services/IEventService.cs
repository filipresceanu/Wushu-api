using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface IEventService
    {
        Task CreateEvent(Event competiton);

        Task<IEnumerable<EventDto>> GetEvents(); 

        Task<Event>GetEvent(Guid id);
    }
}
