using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    public interface IRabbitMQConnection: IDisposable
    {
        public bool IsConnected { get; }   
        public IModel CreateModel ();
    }
}
