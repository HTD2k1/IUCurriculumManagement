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
                // This function is idempotent. Hence, it will not create queues that are duplicate to any existing queues
                _rabbitMQConnection.Channel.QueueDeclare(queue, durable: true, exclusive:false, autoDelete: false);
                _rabbitMQConnection.Channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);  
            }
        }

        public void PublishCurriculumEvent(CurriculumEvent newEvent)
        {
            var queueName = newEvent.GetQueueName();
            var msgBody = newEvent.ToJSON();

            _rabbitMQConnection.Channel.BasicPublish(exchange: string.Empty,
                                                    routingKey: queueName,
                                                    basicProperties: null,
                                                    body: Encoding.UTF8.GetBytes(msgBody));
        }

        public void BasicPublishMessage(string message, string exChangeName, string queueName, IBasicProperties properties = null!)
        {
            _rabbitMQConnection.Channel.BasicPublish(exchange: exChangeName,
                                        routingKey: queueName,
                                        basicProperties: properties,
                                        body: Encoding.UTF8.GetBytes(message));
        }
        public void Dispose()
        {
            _rabbitMQConnection.Dispose();  
        }
    }
}
