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
        public async Task<List<Event>> AddEvent(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return await _context.Events.ToListAsync();
        }
        // ServiceResponse!
        public async Task<List<Event>?> DeleteEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev is null)
                return null;

            _context.Events.Remove(ev);

            await _context.SaveChangesAsync();

            return await _context.Events.ToListAsync();
        }
        // ServiceResponse!
        public async Task<List<Event>> GetAllEvents()
        {
            var events = await _context.Events.ToListAsync();
            return events;
        }
        // ServiceResponse!
        public async Task<Event?> GetSingleEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);

            if (ev is null)
                return null;

            return ev;
        }
        // ServiceResponse!
        public async Task<List<Event>?> UpdateEvent(int id, Event request)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev is null)
                return null;

            ev.Title = request.Title;
            ev.Description = request.Description;
            ev.StartDate = request.StartDate;
            ev.EndDate = request.EndDate;
            ev.Address = request.Address;
            ev.City = request.City;
            ev.Price = request.Price;

            await _context.SaveChangesAsync();

            return await _context.Events.ToListAsync();
        }
    }
}
