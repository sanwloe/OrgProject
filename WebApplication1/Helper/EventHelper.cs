using WebApplication1.Model;

namespace WebApplication1.Helper
{
    public static class EventHelper
    {
        public static void UpdateEvent(this Event @event,Event newData)
        {
            @event.Date = newData.Date;
            @event.Title = newData.Title;
            @event.Description = newData.Description;
        }
    }
}
