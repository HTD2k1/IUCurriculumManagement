using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQService.Interfaces;

namespace RabbitMQService
{
    public class RabbitMQDefaultConnection: IRabbitMQConnection
    {
        private readonly RabbitMQSettings _settings;
        private readonly int _retryCount;
        private IConnection _connection;
        private IModel _channel;
        private readonly ILogger<RabbitMQDefaultConnection> _logger;
        public IModel Channel { get =>_channel; }
        public RabbitMQSettings Settings { get => _settings; }
        public bool Disposed; //Default value is false

        public RabbitMQDefaultConnection(IOptions<RabbitMQSettings> options, ILogger<RabbitMQDefaultConnection> logger) { 
            _settings= options.Value ?? throw new ArgumentNullException(nameof(options));
            var factory = new ConnectionFactory
            {
                HostName = _settings.Hostname,
                Port = _settings.Port,
                UserName = _settings.UserName,
                Password = _settings.Password
            };
            _logger = logger;
            _connection = factory.CreateConnection(_settings.ServiceName);
            _channel = CreateChannel();
            //_channel.QueueDeclare(queue: _settings.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public bool IsConnected => _connection is { IsOpen: true } && !Disposed;
        public IModel CreateChannel()  => (!IsConnected) ? throw new InvalidOperationException(" No RabbitMQ Connections available"): _connection.CreateModel();   

        public void Dispose() { 
            if (Disposed) return;
            try
            {   
                _connection.Dispose();
            }
            catch(Exception ex)
            {
                _logger.LogError($"RabbitMQ Connection Disposal Failed: {ex}");
            }
        }
    }
}
