using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer {
    
    public class  Consumer
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            int sum = 0;
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
                var stringArr = message.Split(" ");
                
                foreach(var item in stringArr ) {
                    sum += int.Parse(item);
                }
                Console.WriteLine($"Total course updated : {sum}");
            };
            channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);
            
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

}
