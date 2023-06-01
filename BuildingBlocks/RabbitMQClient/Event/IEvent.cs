using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService.Event
{
    public interface IEvent
    {
        public string ToJSON();
        //public string GetQueueName();
    }
}
