using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.App.Test.Models;
using Web.App.Test.RabbitBroker.Connection;
using Web.App.Test.RabbitBroker.Connection.Settings;

namespace Web.App.Test.RabbitBroker.Publisher
{
    public class Publisher : IPublisher
    {
        private IRabbitConnection _rabbitConnection;
        private readonly ISetting _setting;

        public Publisher(IRabbitConnection rabbitConnection, ISetting setting)
        {
            _rabbitConnection = rabbitConnection;
            _setting = setting;
        }

        public bool PublishMessage(PlayerModel playerModel)
        {
            try
            {
                using (var channel = _rabbitConnection.Connect().CreateModel())
                {
                    var message = Newtonsoft.Json.JsonConvert.SerializeObject(playerModel);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: _setting.ExchangeName,
                                         routingKey: _setting.RoutingKey,
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch (Exception e)
            { return false; }

            return true;
        }
    }
}
