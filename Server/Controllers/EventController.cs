using EventsApp.Server.Services.EventService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        public async Task<ActionResult<ServiceResponse<List<Event>>>> GetEvents()
        {
            var result = await _eventService.GetEvents();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Event>>> GetEvent(int id)
        {
            var result = await _eventService.GetEvent(id);
            return Ok(result);
        }    
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Event>>> AddEvent(Event ev)
        {
            var result = await _eventService.AddEvent(ev);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Event>>> UpdateEvent(Event ev)
        {
            var result = await _eventService.UpdateEvent(ev);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEvent(id);
            return Ok(result);
        }
    }
}
