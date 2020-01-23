using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using RabbitMQ.Client.Events;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway.Setup
{

    //Fix this setup stuff it is dumb and should be done in another way.
    public class DeclarePassiveInitializer :RabbitMQInitializer
    {

        
        public DeclarePassiveInitializer(ConnectionWrapper connectionWrapper) : base(connectionWrapper)
        {
        }

        protected override void DeclareExchanges(params string[] exchangeNames)
        {
            using (var channel = _connection.NewChannel())
            {
                foreach (var exchangeName in exchangeNames)
                {

                    channel.ExchangeDeclarePassive(exchangeName);
                }

            }
        }
    }
}
