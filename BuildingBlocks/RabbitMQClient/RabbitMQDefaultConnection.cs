using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQClient
{
    public class RabbitMQDefaultConnection: IRabbitMQConnection
    {
        private readonly IConnectionFactory _factory;
        private readonly int _retryCount;
        private IConnection _connection;
        public bool Disposed;

        public RabbitMQDefaultConnection(IConnectionFactory factory, int retryCount = 5) { 
            _factory= factory ?? throw new ArgumentNullException(nameof(factory));
            _retryCount= retryCount;
            _connection = factory.CreateConnection();   
        }

        public bool IsConnected => _connection is { IsOpen: true } && Disposed;
        public IModel CreateModel()  => (!IsConnected) ? throw new InvalidOperationException(" No RabbitMQ Connections available"): _connection.CreateModel();   
        
        public void Dispose() { 
            if (Disposed) return;
            try
            {   
                _connection.Dispose();
            }
            catch(Exception ex)
            {
                // TO DO: Add logger here 
            }
        }
    }
}
