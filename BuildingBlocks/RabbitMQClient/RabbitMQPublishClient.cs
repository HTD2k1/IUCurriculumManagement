using RabbitMQ.Client;
using System.Text;

namespace RabbitMQClient
{
    public class RabbitMQPublishClient
    {
       public static void Publish(string message,string queueName, string exchangeName = "")
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.BasicPublish(exchange: string.Empty,
                                                    routingKey: queueName,
                                                    basicProperties: null,
                                                    body: Encoding.UTF8.GetBytes(message));
        }
    }
}
