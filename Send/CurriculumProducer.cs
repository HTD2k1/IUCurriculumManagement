using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using CsvHelper.Expressions;
using RabbitMQ.Client;

namespace CurriculumProducer
{
    public class CurriculumProducer
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var body = " {\"EventType\":3,\"Payload\":\"CTT-CS-k21-plain.docx\",\n \"Id\":\"108b3492-063d-45ba-b020-6fca8a78f33c\", \n \"DateTime\":\"2023-05-18T11:50:15.4545929+07:00\"}";
            for (int i = 0; i < 100; i++)
            {
                channel.BasicPublish(exchange: string.Empty,
                                         routingKey: "curriculum-processed",
                                         basicProperties: null,
                                         body: Encoding.UTF8.GetBytes(body));
            }
            Console.WriteLine($"Message Content: "+body);
            int[] testList = { 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000, 200000,500000, 1000000 };
            channel.BasicPublish(exchange: string.Empty,
                                          routingKey: "curriculum-processed",
                                          basicProperties: null,
                                          body: Encoding.UTF8.GetBytes(body));
            foreach (var no in testList)
            {
                Console.WriteLine($"Initiating Throughput test with {no} messages");
                Stopwatch stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < no; i++)
                {
                    channel.BasicPublish(exchange: string.Empty,
                                            routingKey: "curriculum-processed",
                                            basicProperties: null,
                                            body: Encoding.UTF8.GetBytes(body));
                }
                stopwatch.Stop();
                Console.WriteLine($"Total time taken: {stopwatch.Elapsed.TotalMilliseconds} ms");
                //channel.QueuePurge("curriculum-processed");
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
