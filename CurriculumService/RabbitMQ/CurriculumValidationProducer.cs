using RabbitMQ.Client;

namespace CurriculumService.RabbitMQ
{
    public class CurriculumValidationProducer: IRabbitMQProducer
    {   
        public void SendMessage()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Accepted queue declaration
            channel.QueueDeclare(queue: "curriculum-accepted", durable: true, exclusive: false, autoDelete: false);
            channel.BasicPublish(exchange: string.Empty, routingKey: "curriculum.accepted");

            // Decline queue declaration
            channel.QueueDeclare(queue: "curriculum.decline", durable: true, exclusive: false, autoDelete: false);
            channel.BasicPublish(exchange: string.Empty, routingKey: "curriculum.declined");

        }
    }   
}
