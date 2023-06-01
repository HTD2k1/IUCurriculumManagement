using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService.Event
{
    public class OnlineCheckingEvent: IEvent
    {   
        public Guid EventId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceStatus { get; set; }

        public OnlineCheckingEvent( string serviceName, string serviceStatus)
        {
            EventId = Guid.NewGuid();
            ServiceName = serviceName;
            ServiceStatus = serviceStatus;
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

