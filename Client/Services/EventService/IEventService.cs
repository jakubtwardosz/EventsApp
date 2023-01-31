namespace EventsApp.Client.Services.EventService
{
    public interface IEventService
    {
        List<Event> Events { get; set; }
        Task GetEvents();
        Task<ServiceResponse<Event>> GetEvent(int id);       
        Task<Event> AddEvent(Event ev);
        Task<Event> UpdateEvent(Event ev);
        Task DeleteEvent(Event ev);
    }
}