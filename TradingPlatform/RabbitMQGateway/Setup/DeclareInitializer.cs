using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway.Setup
{
    public class DeclareInitializer :RabbitMQInitializer
    {
        public DeclareInitializer(ConnectionWrapper connectionWrapper) : base(connectionWrapper)
        {
        }


        protected override void DeclareExchanges(params string[] exchangeNames)
        {

            using (var channel = _connection.NewChannel())
            {
                foreach (var exchangeName in exchangeNames)
                {

                    channel.ExchangeDeclare(exchangeName, "topic", true, false, null);
                }

            }
        }
    }
}
