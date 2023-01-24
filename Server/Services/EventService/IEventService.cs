namespace EventsApp.Server.Services.EventService
{
    public interface IEventService
    {
        List<Event> GetAllEvents();
        Event? GetSingleEvent(int id);
        List<Event> AddEvent(Event newEvent);
        List<Event>? UpdateEvent(int id, Event request);
        List<Event>? DeleteEvent(int id);
    }
}
