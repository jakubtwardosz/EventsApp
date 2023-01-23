using EventsApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            var events = new List<Event> { 
                new Event { Id = 1, Title = "Hello world", Description = "The first event" } };

            return Ok(events);
        }
    }
}
