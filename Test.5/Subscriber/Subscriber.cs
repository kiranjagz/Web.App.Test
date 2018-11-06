using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test._5.Models;
using Test._5.Repository;

namespace Test._5.Subscriber
{
    public class Subscriber
    {
        EventingBasicConsumer _eventBasicConsumer;
        private readonly ISqlRepository _sqlRepository;

        public Subscriber(IConnection connection, ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;

            var model = connection.CreateModel();
            model.BasicQos(0, 1, false);
            _eventBasicConsumer = new EventingBasicConsumer(model);
            _eventBasicConsumer.Received += EventBasicConsumer_ReceivedAsync;
            model.BasicConsume("webapp-inbound-queue", true, _eventBasicConsumer);
        }

        private async void EventBasicConsumer_ReceivedAsync(object sender, BasicDeliverEventArgs e)
        {
            var eventModel = Encoding.UTF8.GetString(e.Body);
            var player = JsonConvert.DeserializeObject<PlayerModel>(eventModel);

            await _sqlRepository.SaveAsync(player).ContinueWith(x =>
            {
                Console.WriteLine($"Data inserted into table: {JsonConvert.SerializeObject(player)}");
            });
        }
    }
}
