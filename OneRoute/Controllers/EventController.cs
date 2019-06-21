using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neleus.DependencyInjection.Extensions;
using OneRoute.Events;
using OneRoute.Events;
using OneRoute.Swagger;
using Swashbuckle.AspNetCore.Filters;

namespace OneRoute.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IServiceByNameFactory<IEventHandler> _eventFactory;
        public EventController(IServiceByNameFactory<IEventHandler> eventFactory)
        {
            _eventFactory = eventFactory;
        }
        // POST api/event
        [HttpPost]
        [SwaggerRequestExample(typeof(EventDown),typeof(EventDownExample))]
        public async Task<string> PostAsync([FromBody] Event @event)
        {
            var handler = _eventFactory.GetByName(@event.EventType);
            return await handler.Handle();
        }
    }
}
