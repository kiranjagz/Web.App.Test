using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.App.Test.Models;

namespace Web.App.Test.RabbitBroker.Publisher
{
    public interface IPublisher
    {
        bool PublishMessage(PlayerModel playerModel);
    }
}
