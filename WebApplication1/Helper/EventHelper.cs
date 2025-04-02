using WebApplication1.Model;

namespace WebApplication1.Helper
{
    public static class EventHelper
    {
        public static bool DateIsValid(this Event @event)
        {
            return @event.Date > DateTime.Now;
        }
        public static void UpdateEvent(this Event @event,Event newData)
        {
            @event.Date = newData.Date;
            @event.Title = newData.Title;
            @event.Description = newData.Description;
        }
    }
}
