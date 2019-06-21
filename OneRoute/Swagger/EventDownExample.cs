using OneRoute.Events;
using OneRoute.Events;
using Swashbuckle.AspNetCore.Filters;

namespace OneRoute.Swagger
{
    public class EventDownExample : IExamplesProvider<Event>
    {
        public Event GetExamples()
        {
            return new EventDown
            {
                EventType = nameof(EventDown)
            };
        }
    }
}
