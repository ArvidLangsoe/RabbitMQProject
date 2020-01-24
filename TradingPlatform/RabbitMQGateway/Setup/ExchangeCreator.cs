using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway.Setup
{
    public class ExchangeCreator
    {
        private readonly ConnectionFactory _connectionFactory;

        public ExchangeCreator(ConnectionFactory connectionFactory, bool declarePassive=false)
        {
            _connectionFactory = connectionFactory;
            if (declarePassive)
            {
                DeclareExchangesPassive(Exchange.Sell, Exchange.Buy, Exchange.Info);
            }
            else
            {
                DeclareExchanges(Exchange.Sell, Exchange.Buy, Exchange.Info);
            }

        }

        private void DeclareExchanges(params string[] exchangeNames)
        {
            using (var connection = new ConnectionWrapper(_connectionFactory))
            {
                using (var channel = connection.NewChannel())
                {
                    foreach (var exchangeName in exchangeNames)
                    {

                        channel.ExchangeDeclare(exchangeName, "topic", true, false, null);
                    }

                }
            }
        }

        private void DeclareExchangesPassive(params string[] exchangeNames)
        {
            using (var connection = new ConnectionWrapper(_connectionFactory))
            {
                using (var channel = connection.NewChannel())
                {
                    foreach (var exchangeName in exchangeNames)
                    {

                        channel.ExchangeDeclarePassive(exchangeName);
                    }

                }
            }
        }
    }
}
