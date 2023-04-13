using RabbitMQService.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService
{
    public interface IRabbitMQService: IDisposable
    {
        public void PublishEvent(ICurriculumEvent @event);
        public void ConsumeEvent(ICurriculumEvent @event);
        public void RegisterConsumer();

        public Task ProcessMessageAsync(string message);
    }
}
