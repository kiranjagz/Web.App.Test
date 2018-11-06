using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.App.Test.RabbitBroker.Connection
{
    public interface IRabbitConnection
    {
        IConnection Connect();
    }
}
