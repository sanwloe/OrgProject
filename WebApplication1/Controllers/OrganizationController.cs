using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helper;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api")]
    public class OrganizationController : ControllerBase
    {
        public OrganizationController(DataService dataService)
        {
            _dataService = dataService;
        }
        private DataService _dataService;
        [HttpGet("events")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsAsync()
        {
            var res = await _dataService.GetEventsAsync();
            return Ok(res);
        }
        [HttpGet("events/{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsAsync(int id)
        {
            var item = await _dataService.GetEventByIdAsync(id);
            if(item!=null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("events")]
        public async Task<ActionResult<IEnumerable<Event>>> AddNewEventAsync([FromBody] Event @event)
        {
            var isSuccess = await _dataService.AddNewEventAsync(@event);
            if(isSuccess)
            {
                return Ok(isSuccess);
            }
            else
            {
                return Problem();
            }
        }
        [HttpPut("events/{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> UpdateEventAsync(int id,[FromBody] Event @event)
        {
            var eventForUpdating = await _dataService.GetEventByIdAsync(id);
            if(eventForUpdating!=null)
            {
                eventForUpdating.UpdateEvent(@event);
                var isSuccess = await _dataService.UpdateEventAsync(eventForUpdating);
                if(isSuccess)
                {
                    return Ok(isSuccess);
                }
                else
                {
                    return ValidationProblem();
                }
            }
            return NotFound();
        }
        [HttpDelete("events/{id}")]
        public async Task<ActionResult> RemoveEventAsync(int id)
        {
            var isSuccess = await _dataService.DeleteEventAsync(id);
            if(isSuccess)
            {
                return Ok(isSuccess);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
