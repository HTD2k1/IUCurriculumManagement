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
        public void PublishEvent(ICurriculumEvent @event);
        public void ConsumeEvent(ICurriculumEvent @event);
        public Task RegisterConsumer();
    }
}
