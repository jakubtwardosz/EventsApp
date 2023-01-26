

namespace EventsApp.Client.Services.EventService
{
    public class EventService : IEventService
    {
        private readonly HttpClient _http;

        public EventService(HttpClient http)
        {
            _http = http;
        }

        public List<Event> Events { get; set; } = new List<Event>();

        public async Task<ServiceResponse<Event>> GetEvent(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Event>>($"api/Event{id}");
            return result;
        }

        public async Task GetEvents()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Event>>>("api/Event");
            if (result != null && result.Data != null)
                Events = result.Data;
        }
    }
}
