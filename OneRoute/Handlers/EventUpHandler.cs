using OneRoute.Events;
using System.Threading.Tasks;

namespace OneRoute.Handlers
{
    public class EventUpHandler : IEventHandler
    {
        public async Task<string> Handle()
        {
            await Task.CompletedTask;
            return "Event up was called";
        }
    }
}
