using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" }; 
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "Hello", durable: true, exclusive:  false, autoDelete: false, arguments: null);
const string message = "First message";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: string.Empty, routingKey: "hello", basicProperties: null, body: body);
Console.WriteLine($" [x] Sent {message}");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();


