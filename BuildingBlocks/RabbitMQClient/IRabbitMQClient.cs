using RabbitMQClient.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    public interface IRabbitMQClient
    {
        public void Publish(ICurriculumEvent @event);
        public void Consume(ICurriculumEvent @event);
    }
}
