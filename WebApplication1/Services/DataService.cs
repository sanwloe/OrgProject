using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Helper;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public class DataService
    {
        public DataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        private DataContext _dataContext;

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            var res = await _dataContext.Events.ToListAsync();
            return res;
        }
        public async Task<Event?> GetEventByIdAsync(int id)
        {
            return await _dataContext.Events.Include(x => x.Organization).FirstOrDefaultAsync(x => x.EventId == id);
        }
        public async Task<bool> AddNewEventAsync(Event item)
        {
            var isValid = item.DateIsValid();
            if (isValid)
            {
                await _dataContext.Events.AddAsync(item);
                await _dataContext.SaveChangesAsync();
            }
            return isValid;
        }
        public async Task<bool> UpdateEventAsync(Event item)
        {
            var isValid = item.DateIsValid();
            if(isValid)
            {
                _dataContext.Events.Update(item);
                await _dataContext.SaveChangesAsync();
            }
            return isValid;
        }
        public async Task<bool> DeleteEventAsync(int id)
        {
            var @event = await _dataContext.Events.FirstOrDefaultAsync(x => x.EventId == id);
            if(@event != null)
            {
                _dataContext.Events.Remove(@event);
                await _dataContext.SaveChangesAsync();
            }
            return @event != null;
        }
    }
}
