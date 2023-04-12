using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient.Event
{
    public interface ICurriculumEvent
    {
        public string ToJSON();
        public string GetQueueName();
    }
}
