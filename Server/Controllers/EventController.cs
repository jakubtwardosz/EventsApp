using EventsApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private static List<Event> events = new List<Event> {
                new Event
                {   Id = 1,
                    Title = "Hello world",
                    Description = "The first event"
                },
                new Event
                {   Id = 2,
                    Title = "Goodbye world",
                    Description = "The last event"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Event>>> GetSingleEvent(int id)
        {
            var singleEvent = events.Find(x => x.Id == id);

            if (singleEvent is null)
                return NotFound("This event does not exist");

            return Ok(singleEvent);
        }

        [HttpPost]
        public async Task<ActionResult<List<Event>>> AddEvent(Event newEvent)
        {
            events.Add(newEvent);
            return Ok(events);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Event>>> UpdateEvent(int id, Event request)
        {
            var updatedEvent = events.Find(x => x.Id == id);
            if (updatedEvent is null)
                return NotFound("This event does not exist");

            updatedEvent.Title = request.Title;
            updatedEvent.Description = request.Description;

            return Ok(events);
        }
    }
}
