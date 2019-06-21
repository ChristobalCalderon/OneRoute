using System;
using System.Threading.Tasks;

namespace OneRoute.Events
{
    public interface IEventHandler
    {
        Task<string> Handle();
    }
}
