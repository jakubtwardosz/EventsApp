namespace EventsApp.Server.Services.EventService
{
    public class EventService : IEventService
    {
        private readonly DataContext _context;

        public EventService(DataContext context)
        {
            _context = context;
        }

        // ServiceResponse!
/*        public async Task<ServiceResponse<List<Event>>> AddEvent(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return await _context.Events.ToListAsync();
        }*/
        // ServiceResponse!
/*        public async Task<ServiceResponse<List<Event>?>> DeleteEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev is null)
                return null;

            _context.Events.Remove(ev);

            await _context.SaveChangesAsync();

            return await _context.Events.ToListAsync();
        }*/
        public async Task<ServiceResponse<List<Event>>> GetEvents()
        {
            var response = new ServiceResponse<List<Event>>()
            {
                Data = await _context.Events.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Event?>> GetEvent(int id)
        {
            var response = new ServiceResponse<Event>();
            var ev = await _context.Events.FindAsync(id);

            if (ev == null)
            {
                response.Success = false;
                response.Message = "Event is not exist.";
            }
            else
            {
                response.Data= ev;
            }

            return response;
        }

        // ServiceResponse!
        /*        public async Task<ServiceResponse<List<Event>?>> UpdateEvent(int id, Event request)
                {
                    var ev = await _context.Events.FindAsync(id);
                    if (ev is null)
                        return null;

                    ev.Title = request.Title;
                    ev.Description = request.Description;
                    ev.StartDate = request.StartDate;
                    ev.Address = request.Address;
                    ev.City = request.City;
                    ev.Price = request.Price;

                    await _context.SaveChangesAsync();

                    return await _context.Events.ToListAsync();
                }*/
    }
}
