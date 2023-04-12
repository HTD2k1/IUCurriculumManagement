using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQClient.Event;
using System.Text;
using Newtonsoft.Json;

namespace RabbitMQClient
{
    public class RabbitMQBaseClient: IRabbitMQClient
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;
        public RabbitMQBaseClient(IRabbitMQConnection rabbitMQConnection)
        {
            _rabbitMQConnection = rabbitMQConnection ?? throw new ArgumentNullException(nameof(rabbitMQConnection));   
        }
       public void Publish(ICurriculumEvent newEvent)
        {
            var channel = _rabbitMQConnection.CreateModel();
            var queueName = newEvent.GetQueueName();
            var msgBody = newEvent.ToJSON();

            channel.BasicPublish(exchange: string.Empty,
                                                    routingKey: queueName,
                                                    basicProperties: null,
                                                    body: Encoding.UTF8.GetBytes(msgBody));
        }

        public void Consume(ICurriculumEvent newEvent)
        {
            var channel = _rabbitMQConnection.CreateModel();
            var queueName = newEvent.GetQueueName();
            var msgBody = newEvent.ToJSON();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var consumedEvent = JsonConvert.DeserializeObject<CurriculumEvent>(message);
                Console.WriteLine(message.ToString());
            };
        }



    }
}
