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
    public class RabbitMQPublishService: IRabbitMQPublishService
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;
        private readonly ILogger<RabbitMQPublishService> _logger;
        public RabbitMQPublishService(IRabbitMQConnection rabbitMQConnection, ILogger<RabbitMQPublishService> logger)
        {
            _rabbitMQConnection = rabbitMQConnection ?? throw new ArgumentNullException(nameof(rabbitMQConnection));   
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
