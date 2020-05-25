using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
namespace Consumer
{
    class Receiver
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel()) 
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received message {0}...", message);
                };
                
                channel.BasicConsume("BasicTest", true, consumer);
                
                while (true) {
                    Thread.Sleep(60*1000);
                    Console.WriteLine("sleeping");
                }
                //Console.WriteLine("Press [enter] to exit the Consumer ...");
                //Console.ReadLine();
            }
        }
    }
}
