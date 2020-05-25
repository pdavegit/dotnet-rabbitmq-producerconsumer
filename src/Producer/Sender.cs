using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading;
namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory () { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                long i = 0;
                while (true) {
                    string message = "Getting started with .Net Core RabbitMQ " + i.ToString() ;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "BasicTest", null, body);
                    Console.WriteLine("Sent message {0}...", message);
                    Thread.Sleep(1*1000);
                    ++i;
                }
            }
        }
    }
}
