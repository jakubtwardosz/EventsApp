using EventsApp.Server.Services.EventService;
using EventsApp.Server.Controllers;
using EventsApp.Shared;

namespace TestProject
{
    public class UnitTest1 : IEventService
    {
        private readonly IEventService _eventService;

        public UnitTest1(IEventService eventService)
        {
            _eventService = eventService;
        }

        public Task<ServiceResponse<Event>> AddEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        
        public Task<ServiceResponse<Event>> GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Event>>> GetEvents()
        {
            throw new NotImplementedException();
        }        

        public Task<ServiceResponse<Event>> UpdateEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        /*[Fact]
        public async void Get_First_Event()
        {
            var id = 1;
            var response = await _eventService.GetEvent(id);

            Console.WriteLine(response);
        }*/
    }
}