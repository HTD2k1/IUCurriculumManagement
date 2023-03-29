using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text;

namespace CurriculumMeditator
{
    public class RabbitMQPublishClient
    {
       public static void Publish(string message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.BasicPublish(exchange: string.Empty,
                                                    routingKey: "curriculum-created",
                                                    basicProperties: null,
                                                    body: Encoding.UTF8.GetBytes(message));
        }
    }
}
