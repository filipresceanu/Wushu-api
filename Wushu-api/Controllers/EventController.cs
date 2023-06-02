using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Services;

namespace Wushu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private IMapper _mapper;
        public EventController(IEventService eventService,IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPut("add-event")]
        public async Task<ActionResult>AddEvent(EventDto competition)
        {
            var _competition=new Event{
                
                Name=competition.Name,
                Date= competition.Date,
                Participants=new Collection<Participant>()

                 };

            await _eventService.CreateEvent(_competition);
            return Ok("Success");
        }
        [HttpGet("get-event")]
        public async Task<ActionResult<IEnumerable<EventDto>>>GetEvents()
        {
            var _competition=await _eventService.GetEvents();
            return Ok(_competition);
        }
    }
}
