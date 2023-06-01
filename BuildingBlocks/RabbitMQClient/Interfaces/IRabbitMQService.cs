using RabbitMQService.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService.Interfaces
{
    public interface IRabbitMQService : IDisposable
    {
        //public void PublishEvent(IEvent @event);
        //public void ConsumeEvent(IEvent @event);
        public Task RegisterConsumer();
    }
}
