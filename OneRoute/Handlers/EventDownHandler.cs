using OneRoute.Events;
using System.Threading.Tasks;

namespace OneRoute.Handlers
{
    public class EventDownHandler : IEventHandler
    {
        public async Task<string> Handle()
        {
            await Task.CompletedTask;
            return "Event down was called";
        }
    }
}
