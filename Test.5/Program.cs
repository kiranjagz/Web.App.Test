using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test._5.Repository;

namespace Test._5
{
    class Program
    {
        private static IConnectionFactory _connectionFactory;
        private static IConnection _connection;

        static void Main(string[] args)
        {
            Console.WriteLine($"Listening for events from rabbit :)");

            _connectionFactory = new ConnectionFactory { HostName = "localhost" };
            _connection = _connectionFactory.CreateConnection();

            var sub = new Subscriber.Subscriber(_connection, new SqlRepository());

            Console.Read();
        }
    }
}
