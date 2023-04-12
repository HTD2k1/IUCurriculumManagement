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
        private readonly IConnection _connection;
        private readonly int _retryCount;
        public bool Disposed;

        public RabbitMQDefaultConnection(IConnectionFactory factory, IConnection connection, int retryCount = 5) { 
            _factory= factory ?? throw new ArgumentNullException(nameof(factory));
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _retryCount= retryCount;
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
