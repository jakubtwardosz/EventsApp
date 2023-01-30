namespace EventsApp.Server.Services.EventService
{
    public interface IEventService
    {
        Task<ServiceResponse<List<Event>>> GetEvents();
        Task<ServiceResponse<Event>> GetEvent(int id);
        Task<ServiceResponse<Event>> AddEvent(Event ev);
        Task<ServiceResponse<bool>> DeleteEvent(int id);
        Task<ServiceResponse<Event>> UpdateEvent(Event ev);
        Task<ServiceResponse<int>> GetEventId(int id);
        Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address);
        Task<ServiceResponse<Address>> GetAddress(int eventId);
    }
}
