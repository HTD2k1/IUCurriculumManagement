﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQService.Event;
using System.Text;
using Newtonsoft.Json;
using System.Runtime;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;

namespace RabbitMQService
{
    public class RabbitMQService: IRabbitMQService
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;
        private readonly ILogger<RabbitMQService> _logger;   
        public RabbitMQService(IRabbitMQConnection rabbitMQConnection, ILogger<RabbitMQService> logger)
        {
            _rabbitMQConnection = rabbitMQConnection ?? throw new ArgumentNullException(nameof(rabbitMQConnection));   
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                
                Console.WriteLine(message.ToString());
            };
        }

        public void RegisterConsumer()
        {
            var consumer = new AsyncEventingBasicConsumer(_rabbitMQConnection.Channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await ProcessMessageAsync(message);
            };
            _rabbitMQConnection.Channel.BasicConsume(queue: _rabbitMQConnection.Settings.QueueName, autoAck: true, consumer: consumer);
        }
        public async Task ProcessMessageAsync(string message)
        {
            // Process the message and do something with it
            var consumedEvent = JsonConvert.DeserializeObject<CurriculumEvent>(message);
           _logger.LogInformation($"Received: {message}");
        }
         
        public void Dispose()
        {
            _rabbitMQConnection.Dispose();  
        }
    }
}
