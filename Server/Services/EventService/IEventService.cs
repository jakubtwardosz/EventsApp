namespace EventsApp.Server.Services.EventService
{
    public interface IEventService
    {
        Task<ServiceResponse<List<Event>>> GetEvents();
/*        Task<ServiceResponse<Event?>> GetSingleEvent(int id);
        Task<ServiceResponse<List<Event>>> AddEvent(Event ev);
        Task<ServiceResponse<List<Event>?>> UpdateEvent(int id, Event request);
        Task<ServiceResponse<List<Event>?>> DeleteEvent(int id);*/
    }
}
