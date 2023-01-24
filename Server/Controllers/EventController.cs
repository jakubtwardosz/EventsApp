using EventsApp.Server.Services.EventService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {

            var result = _eventService.GetAllEvents();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Event>>> GetSingleEvent(int id)
        {
            var result = _eventService.GetSingleEvent(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Event>>> AddEvent(Event newEvent)
        {
            var result = _eventService.AddEvent(newEvent);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Event>>> UpdateEvent(int id, Event request)
        {
            var result = _eventService.UpdateEvent(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Event>>> DeleteEvent(int id)
        {
            var result = _eventService.DeleteEvent(id);
            if (result is null)
                return NotFound("This event does not exist");
            return Ok(result);
        }

    }
}
