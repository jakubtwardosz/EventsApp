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

        private static List<Event> Events = new List<Event>
        {
           new Event
           {
               Id = 1,
               UserId = 1,
               Title = "BASSTARDS 2.0: MATT GREEN / FATHERTZ",
               Description = "Duet didżejski FATHERTZ po raz drugi wjeżdza do naszej piwnicy! 😎 Misje mają jedną - zadbać o najniższe częstotliwości i wymassssowac Wam uszy porządnym basssem!",
               ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/325594825_1452561625273197_3749631723571176120_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=RPCrtPASyDIAX9MB_xX&_nc_ht=scontent-waw1-1.xx&oh=00_AfAJiX5QePPXw7IBI7rUL9YOnu4h3EnLJ1ahB3DZ1cVBNA&oe=63D7FFC4",
               StartDate = new DateTime(2023, 2, 17, 23, 00, 00),
               Address = "ul. Plac Wolnica 10",
               City = "Kraków",
               Price = 7.99M
           },
           new Event
           {
               Id = 2,
               UserId = 2,
               Title = "Digital Organism VI: Unkey & MC Toast // Powered By Ashwagundub Soundsystem // 3 Urodziny",
               Description = "Digital Organism to cykl imprez, na których nie będziemy się z Wami pieścić. Nie obiecujemy cukierkowego klimatu. Nie zobaczycie męczących stroboli w klubie. Tylko kawał dobrej roboty muzyków oraz dekoratorów",
               ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/315829423_1529741864136995_8866568946256025211_n.jpg?stp=dst-jpg_p180x540&_nc_cat=105&ccb=1-7&_nc_sid=340051&_nc_ohc=WJBxHfhRbiAAX-zVYOa&_nc_ht=scontent-waw1-1.xx&oh=00_AfB2F_YjMScJ7J0hhZjb1AgUxQbYR5YMOwJ4FDFwCd5TJg&oe=63D7EE83",
               StartDate = new DateTime(2023, 2, 24, 23, 00, 00),
               Address = "Niepodległości 36",
               City = "Poznań",
               Price = 8.99M
           },
           new Event
           {
               Id = 3,
               UserId = 3,
               Title = "Bejsufka #2 | DNB | Klub Baza",
               Description = "Siemanko dramendbejsowe świry! Tak jak obiecaliśmy - wracamy z drugą edycją bejsufki już 25 lutego w Klubie Baza! 🚀",
               ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/326033232_2387371144758789_8496355661206030946_n.jpg?stp=dst-jpg_s960x960&_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=WEKz1t0EdTQAX8zFbCQ&_nc_ht=scontent-waw1-1.xx&oh=00_AfCWRLHboZu7k0P7sR3iMwzXokrrJfYoQJibNDnFpdRNtQ&oe=63D6DFAD",
               StartDate = new DateTime(2023, 2, 25, 22, 00, 00),
               Address = "Mostowa 2",
               City = "Kraków",
               Price = 9.99M
           }
        };

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
