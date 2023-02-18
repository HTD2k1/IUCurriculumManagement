using System.Runtime.CompilerServices;
using System.Text;
using CsvHelper.Expressions;
using RabbitMQ.Client;
using static Producer.CsvHelper;

namespace Producer
{
    public class Producer
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

            var body = TestCsv();
            channel.BasicPublish(exchange: string.Empty,
                                    routingKey: "hello",
                                    basicProperties: null,
                                    body: body);

            TestWord();
         
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
        
        private static byte[] TestCsv()
        {
            // Test Csv
            var testData = CsvHelper.ReadCSV("C:/Users/DAT/source/repos/HTD2k1/RabbitMQGettingStarted/Send/data/curriculum_DS_18-22.csv");
            var years = testData.Select(x => x.year);
            string message = string.Join(" ", years);
            var body = Encoding.UTF8.GetBytes(message);
            Console.WriteLine($" [x] Sent {message}");
            return body;
        }

        private static void TestWord()
        {
           DocxHelper.ReadTablesFromWordDocument("C:/Users/DAT/source/repos/HTD2k1/RabbitMQGettingStarted/Send/data/CTT-CS-k21-plain.docx");
        }
    }
}

