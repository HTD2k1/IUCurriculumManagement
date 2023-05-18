using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService.Interfaces
{
    public interface IMessageProcessor
    {
        public Task ProcessMessageAsync(string message);
    }
}
