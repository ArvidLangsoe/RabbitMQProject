using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Trade;
using RabbitMQ.Client;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway.Setup
{
    public class TradeExchangeCreator
    {
        private readonly ConnectionFactory _connectionFactory;

        public TradeExchangeCreator(ConnectionFactory connectionFactory, bool declarePassive=false)
        {
            _connectionFactory = connectionFactory;
            if (declarePassive)
            {
                DeclareExchangesPassive(Exchange.Sell.Name(), Exchange.Buy.Name(), Exchange.Info.Name());
            }
            else
            {
                DeclareExchanges(Exchange.Sell.Name(), Exchange.Buy.Name(), Exchange.Info.Name());
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
