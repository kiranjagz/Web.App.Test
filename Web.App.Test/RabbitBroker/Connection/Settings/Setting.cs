using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.App.Test.RabbitBroker.Connection.Settings
{
    public class Setting : ISetting
    {
        public string HostName { get; private set; } = "localhost";
        public string ExchangeName { get; private set; } = "webapp-inbound";
        public string RoutingKey { get; private set; } = "webapp.message";
        public string QueueName { get; private set; } = "webapp-inbound-queue";
    }
}
