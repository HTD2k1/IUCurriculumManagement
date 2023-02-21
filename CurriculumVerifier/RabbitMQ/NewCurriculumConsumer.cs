using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace CurriculumService.RabbitMQ
{
    public class NewCurriculumConsumer
    {
        public void Consume()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
            };

            channel.BasicConsume(queue: "new_curriculum",
                                autoAck: true,
                                consumer: consumer);
        }
    }
}
