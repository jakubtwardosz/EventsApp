using Azure;
using Azure.Core;
using EventsApp.Shared;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EventsApp.Server.Services.EventService
{
    public class EventService : IEventService
    {
        private readonly DataContext _context;

        public EventService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Event>> AddEvent(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Event> { Data = ev };
        }

        public async Task<ServiceResponse<bool>> DeleteEvent(int id)
        {
            var dbEvent = await _context.Events.FindAsync(id);
            if (dbEvent == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found."
                };
            }

            dbEvent.Deleted = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<Event>> UpdateEvent(Event ev)
        {
            var dbProduct = await _context.Events
                .Include(p => p.Images)
                .FirstOrDefaultAsync(e => e.Id == ev.Id);

            if (dbProduct == null)
            {
                return new ServiceResponse<Event>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Title = ev.Title;
            dbProduct.Description = ev.Description;
            dbProduct.CategoryId = ev.CategoryId;
            dbProduct.Category = ev.Category;
            dbProduct.Date = ev.Date;
            dbProduct.City = ev.City;
            dbProduct.Street = ev.Street;
            dbProduct.Price = ev.Price;
            dbProduct.ImageUrl= ev.ImageUrl;

            var eventImages = dbProduct.Images;
            _context.Images.RemoveRange(eventImages);

            dbProduct.Images = ev.Images;

            await _context.SaveChangesAsync();
            return new ServiceResponse<Event> { Data = ev };
        }

        public async Task<ServiceResponse<List<Event>>> GetEvents()
        {
            var response = new ServiceResponse<List<Event>>()
            {
                Data = await _context.Events
                .Where(e => !e.Deleted)
                .Include(p => p.Images)
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Event>> GetEvent(int id)
        {
            var response = new ServiceResponse<Event>();
            var ev = await _context.Events
                .Include(p => p.Images)
                .FirstOrDefaultAsync(e => e.Id == id && !e.Deleted);

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
    }
}
