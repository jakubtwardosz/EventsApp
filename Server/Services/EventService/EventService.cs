namespace EventsApp.Server.Services.EventService
{
    public class EventService : IEventService
    {
        private static List<Event> events = new List<Event> {
                new Event
                {   Id = 1,
                    Title = "Hello world",
                    Description = "The first event",
                    StartDate = new DateTime(2008, 5, 1, 8, 30, 52),
                    EndDate = DateTime.Now,
                    Address = "Anywhere 1",
                    City = "Nowhere",
                    Price = 9.99M
                },
                new Event
                {   Id = 2,
                    Title = "Goodbye world",
                    Description = "The last event",
                    StartDate = new DateTime(2008, 5, 1, 8, 30, 52),
                    EndDate = DateTime.Now,
                    Address = "Anywhere 1",
                    City = "Nowhere",
                    Price = 9.99M
                }
            };

        public List<Event> AddEvent(Event newEvent)
        {
            events.Add(newEvent);
            return events;
        }

        public List<Event>? DeleteEvent(int id)
        {
            var deletedEvent = events.Find(x => x.Id == id);
            if (deletedEvent is null)
                return null;

            events.Remove(deletedEvent);

            return events;
        }

        public List<Event> GetAllEvents()
        {
            return events;
        }

        public Event? GetSingleEvent(int id)
        {
            var singleEvent = events.Find(x => x.Id == id);

            if (singleEvent is null)
                return null;

            return singleEvent;
        }

        public List<Event>? UpdateEvent(int id, Event request)
        {
            var updatedEvent = events.Find(x => x.Id == id);
            if (updatedEvent is null)
                return null;

            updatedEvent.Title = request.Title;
            updatedEvent.Description = request.Description;
            updatedEvent.StartDate = request.StartDate;
            updatedEvent.EndDate = request.EndDate;
            updatedEvent.Address = request.Address;
            updatedEvent.City = request.City;
            updatedEvent.Price = request.Price;

            return events;
        }
    }
}
