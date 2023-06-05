using RabbitMQ.Client;
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
        public void PublishCurriculumEvent(CurriculumEvent @event);
        public void BasicPublishMessage(string message, string exChangeName, string queueName, IBasicProperties properties=null);

        //public void PublishEvent(IEvent @event);    
        //public void ConsumeEvent(IEvent @event);
        public Task RegisterConsumer();
    }
}
