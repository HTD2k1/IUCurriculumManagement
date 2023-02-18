using RabbitMQ.Client;

namespace CurriculumVerifier.RabbitMQ
{
    public class CurriculumValidationProducer
    {   
        public void Produce()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Accepted queue declaration
            channel.QueueDeclare(queue: "curriculum.accepted", durable: true, exclusive: false, autoDelete: false);
            channel.BasicPublish(exchange: string.Empty, routingKey: "curriculum.accepted");

            // Decline queue declaration
            channel.QueueDeclare(queue: "curriculum.decline", durable: true, exclusive: false, autoDelete: false);
            channel.BasicPublish(exchange: string.Empty, routingKey: "curriculum.declined");



        }

    }
}
