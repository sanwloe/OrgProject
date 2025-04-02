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
            return await _dataContext.Events.Include(x => x.Organization).ToListAsync();
        }
        public async Task<Event?> GetEventByIdAsync(int id)
        {
            return await _dataContext.Events.Include(x => x.Organization).FirstOrDefaultAsync(x => x.EventId == id);
        }
        public async Task<bool> AddNewEventAsync(Event item)
        {
            try
            {
                await _dataContext.Events.AddAsync(item);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public async Task<bool> UpdateEventAsync(Event item)
        {
            try
            {
                _dataContext.Events.Update(item);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteEventAsync(int id)
        {
            try
            {
                var @event = await _dataContext.Events.FirstOrDefaultAsync(x => x.EventId == id);
                if(@event != null)
                {
                    _dataContext.Events.Remove(@event);
                    await _dataContext.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
