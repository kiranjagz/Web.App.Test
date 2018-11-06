using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.App.Test.RabbitBroker.Connection.Settings
{
    public interface ISetting
    {
        string HostName { get; }
        string ExchangeName { get; }
        string RoutingKey { get; }
        string QueueName { get; }
    }
}
