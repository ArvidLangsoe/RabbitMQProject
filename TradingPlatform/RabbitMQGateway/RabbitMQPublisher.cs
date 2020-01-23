using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.MessageQueue;
using Newtonsoft.Json;

namespace RabbitMQGateway
{
    public class RabbitMQPublisher :IPublish
    {
        public RabbitMQConnection _connection;
        public IEnumerable<string> Exchanges { get; }

        public RabbitMQPublisher(RabbitMQConnection connection, RabbitMQSettings settings)
        {
            _connection = connection;
            Exchanges = settings.Exchanges;

            DeclareExchanges(Exchanges);
        }


        public void Publish(MQMessage message)
        {
            string messageSerialised = JsonConvert.SerializeObject(message.Body);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(messageSerialised);
            _connection.Channel.BasicPublish(message.ExchangeName,$"{message.Category}.{message.ItemName}.{message.Request}", false,null , messageBodyBytes);
        }

        private void DeclareExchanges(IEnumerable<string> exchangeNames)
        {
            foreach (var exchangeName in exchangeNames)
            {
                _connection.Channel.ExchangeDeclare(exchangeName, "topic", true, false,null);
            }
        }
    }
}
