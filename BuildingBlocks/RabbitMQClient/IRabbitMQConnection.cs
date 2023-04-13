using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService
{
    public interface IRabbitMQConnection: IDisposable
    {
        public bool IsConnected { get; }
        public RabbitMQSettings Settings { get; }
        public IModel Channel { get; }
        public IModel CreateChannel ();
    }
}
