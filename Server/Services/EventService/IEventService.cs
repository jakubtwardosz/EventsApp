namespace EventsApp.Server.Services.EventService
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEvents();
        Task<Event?> GetSingleEvent(int id);
        Task<List<Event>> AddEvent(Event ev);
        Task<List<Event>?> UpdateEvent(int id, Event request);
        Task<List<Event>?> DeleteEvent(int id);
    }
}
