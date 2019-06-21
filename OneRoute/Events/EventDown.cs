using OneRoute.Events;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneRoute.Events
{
    public class EventDown : Event
    {
        public string EventType { get; set; }
    }
}
