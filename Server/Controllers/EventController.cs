﻿using EventsApp.Server.Services.EventService;
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
            return await _eventService.GetAllEvents();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Event>>> GetSingleEvent(int id)
        {
            var result = await _eventService.GetSingleEvent(id);
            if (result == null)
                return NotFound("This event does not exist");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Event>>> AddEvent(Event ev)
        {
            var result = await _eventService.AddEvent(ev);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Event>>> UpdateEvent(int id, Event request)
        {
            var result = await _eventService.UpdateEvent(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Event>>> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEvent(id);
            if (result is null)
                return NotFound("This event does not exist");
            return Ok(result);
        }

    }
}
