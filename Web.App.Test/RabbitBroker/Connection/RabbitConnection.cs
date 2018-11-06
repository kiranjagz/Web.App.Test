using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.App.Test.RabbitBroker.Connection.Settings;

namespace Web.App.Test.RabbitBroker.Connection
{
    public class RabbitConnection : IRabbitConnection
    {
        private IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;
        private readonly ISetting _setting;

        public RabbitConnection(ISetting setting)
        {
            _setting = setting;
        }

        public IConnection Connect()
        {
            _connectionFactory = new ConnectionFactory() { HostName = _setting.HostName };
            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(_setting.ExchangeName, ExchangeType.Topic, true);

            var args = new Dictionary<string, object>();
            args.Add("x-message-ttl", 60000);

            _model.QueueDeclare(_setting.QueueName, true, false, false, args);
            _model.QueueBind(_setting.QueueName, _setting.ExchangeName, _setting.RoutingKey);

            return _connection;
        }
    }
}
