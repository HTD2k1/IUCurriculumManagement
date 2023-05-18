using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQService.Event;
using System.Text;
using Newtonsoft.Json;
using System.Runtime;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using RabbitMQService.Interfaces;

namespace RabbitMQService
{
    public class RabbitMQService: IRabbitMQService
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;
        private readonly ILogger<RabbitMQService> _logger;
        private readonly IMessageProcessor? _messageProcessor;
        public RabbitMQService(IRabbitMQConnection rabbitMQConnection,IMessageProcessor processor, ILogger<RabbitMQService> logger)
        {
            _rabbitMQConnection = rabbitMQConnection ?? throw new ArgumentNullException(nameof(rabbitMQConnection));   
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogInformation("RabbitMQListenerService Injected Logger");
            _messageProcessor = processor ?? throw new ArgumentNullException(nameof(processor));
        }
        public RabbitMQService(IRabbitMQConnection rabbitMQConnection, ILogger<RabbitMQService> logger)
        {
            _rabbitMQConnection = rabbitMQConnection ?? throw new ArgumentNullException(nameof(rabbitMQConnection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogInformation("RabbitMQListenerService Injected Logger from RabbitMQService");
        }
        public void PublishEvent(ICurriculumEvent newEvent)
        {
            var channel = _rabbitMQConnection.CreateChannel();
            var queueName = newEvent.GetQueueName();
            var msgBody = newEvent.ToJSON();

            channel.BasicPublish(exchange: string.Empty,
                                                    routingKey: queueName,
                                                    basicProperties: null,
                                                    body: Encoding.UTF8.GetBytes(msgBody));
        }

        public void ConsumeEvent(ICurriculumEvent newEvent)
        {
            var channel = _rabbitMQConnection.CreateChannel();
            var queueName = newEvent.GetQueueName();
            var msgBody = newEvent.ToJSON();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
            };
        }

        public async Task RegisterConsumer()
        {
            var consumer = new EventingBasicConsumer(_rabbitMQConnection.Channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await _messageProcessor.ProcessMessageAsync(message);
            };
            foreach (var queue in _rabbitMQConnection.Settings.SubscribeQueues)
            {
                _rabbitMQConnection.Channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
            }
        }

        public void Dispose()
        {
            _rabbitMQConnection.Dispose();  
        }
    }
}
