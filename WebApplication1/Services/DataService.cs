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
                var id = item.OrganizationId == 0 ? 1 : item.OrganizationId;
                var org = await _dataContext.Organizations.FirstOrDefaultAsync(x => x.OrganizationId == id);
                if (org != null)
                {
                    item.Organization = org;
                    await _dataContext.Events.AddAsync(item);
                    await _dataContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }
        public async Task<bool> UpdateEventAsync(int id,Event data)
        {
            try
            {
                var eventForUpdating = await GetEventByIdAsync(id);
                if (eventForUpdating != null)
                {
                    eventForUpdating.UpdateEvent(data);
                    _dataContext.Events.Update(eventForUpdating);
                    await _dataContext.SaveChangesAsync();
                    return true;
                }
                return false;
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
