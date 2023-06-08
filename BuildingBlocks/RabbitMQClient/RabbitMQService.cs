using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQService.Event;
using System.Text;
using Newtonsoft.Json;
using System.Runtime;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using RabbitMQService.Interfaces;
using Common.MicroserviceModels;
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
            _messageProcessor = processor ?? throw new ArgumentNullException(nameof(processor));
        }
        public RabbitMQService(IRabbitMQConnection rabbitMQConnection, ILogger<RabbitMQService> logger)
        {
            _rabbitMQConnection = rabbitMQConnection ?? throw new ArgumentNullException(nameof(rabbitMQConnection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task RegisterConsumer()
        {
            var consumer = CreateBasicConsumer();
            var deadLetterConsumer = CreateDeadLetterConsumer();
            DeclareAndConsumeQueues(_rabbitMQConnection.Settings.SubscribeQueues, consumer);
            return Task.CompletedTask;
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
        private void NotifyServiceManagerWhenConnnectingToRabbitMQ()
        {   
            var startupEvent = new MicroService
            {
                Id = new Guid(_rabbitMQConnection.Settings.ServiceId),
                ServiceName = _rabbitMQConnection.Settings.ServiceName,
                CurrentStatus = new Status
                {
                    Id = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    ServiceStatus = StatusType.Online
                }
            };
            _rabbitMQConnection.Channel.BasicPublish(exchange: string.Empty, routingKey: "service-online", basicProperties: null, body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(startupEvent)));
        }
        public void Dispose()
        {
            _rabbitMQConnection.Dispose();  
        }
       private void DeclareAndConsumeQueues(IEnumerable<string> queues, IBasicConsumer consumer)
       {
            var mainQueueArgs = new Dictionary<string, object>
            {   
                // TO DO: Move queues settings to other places
                //{ "x-dead-letter-exchange", "DeadLetter" },
                //{ "x-dead-letter-routing-key", "dead_letter_queue" },
                //{ "x-message-ttl", 10000 },  // Message TTL in milliseconds
                //{ "x-max-length", 10000000 }  // Maximum queue length
            };
            foreach (var queue in queues)
            {
                // This function is idempotent. Hence, it will not create queues that are duplicate to any existing queues
                _rabbitMQConnection.Channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false, arguments: mainQueueArgs);
                _rabbitMQConnection.Channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
            }
            if (_rabbitMQConnection.Settings.ServiceName != "ServiceManager")
                NotifyServiceManagerWhenConnnectingToRabbitMQ();
       }
        private EventingBasicConsumer CreateBasicConsumer()
        {
            var consumer = new EventingBasicConsumer(_rabbitMQConnection.Channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                try
                {
                    if (_messageProcessor == null)
                    {
                        throw new NullReferenceException();
                    }
                   await _messageProcessor.ProcessMessageAsync(message);
                    _rabbitMQConnection.Channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex) { 
                
                }

            };
            return consumer;
        }
        private EventingBasicConsumer CreateDeadLetterConsumer()
        {
            var deadLetterConsumer = new EventingBasicConsumer(_rabbitMQConnection.Channel);
            deadLetterConsumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                if (_messageProcessor == null)
                {
                    throw new NullReferenceException();
                }

                // Processing the message once more time 
                await _messageProcessor.ProcessMessageAsync(message);
                _rabbitMQConnection.Channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            return deadLetterConsumer;
        }
    }
}
