using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.App.Test.RabbitBroker.Connection.Settings;

namespace Web.App.Test.RabbitBroker.Publisher
{
    public class CreateExchange : ICreateExchange
    {
        private ISetting _setting;

        public CreateExchange(ISetting setting)
        {
            _setting = setting;
        }

        public bool CreateExchange()
        {
            throw new NotImplementedException();
        }
    }
}
