

using EventsApp.Shared;

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

        public async Task<Event> AddEvent(Event ev)
        {
            var result = await _http.PostAsJsonAsync("api/event", ev);
            var newEvent = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Event>>()).Data;
            return newEvent;
        }

        public async Task DeleteEvent(Event ev)
        {
            var result = await _http.DeleteAsync($"api/event/{ev.Id}");
        }

        public async Task<ServiceResponse<Event>> GetEvent(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Event>>($"api/event/{id}");
            return result;
        }

        public async Task GetEvents()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Event>>>("api/event");
            if (result != null && result.Data != null)
                Events = result.Data;
        }

        public async Task<Event> UpdateEvent(Event ev)
        {
            var result = await _http.PutAsJsonAsync($"api/event", ev);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Event>>();
            return content.Data;
        }
    }
}
