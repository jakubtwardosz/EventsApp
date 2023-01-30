/*namespace EventsApp.Server.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly DataContext _context;
        private readonly IEventService _eventService;

        public AddressService(DataContext context, IEventService eventService)
        {
            _context = context;
            _eventService = eventService;
        }

        public async Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address)
        {
            var response = new ServiceResponse<Address>();
            var dbAddress = (await GetAddress()).Data;
            if (dbAddress == null)
            {
                address.EventId = _eventService.
                _context.Addresses.Add(address);
                response.Data = address;
            }
            else
            {
                dbAddress.Street = address.Street;
                dbAddress.City = address.City;
                response.Data = dbAddress;
            }

            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<Address>> GetAddress()
        {
            var eventId = _eventService.GetEventId();
            var address = await _context.Addresses
                .FirstOrDefaultAsync(a => a.EventId == eventId);
            return new ServiceResponse<Address> { Data = address };
        }
    }
}
*/