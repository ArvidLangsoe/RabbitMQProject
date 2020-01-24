using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces.Trade;
using RabbitMQ.Client;
using RabbitMQ.TradeGateway.Setup;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway
{
 
    //TODO: Better name?
    public class QueueManager :ISubscribable
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly RabbitMQUserSettings _userSettings;
        private readonly List<QueueConnection> _queueConnections;

        public QueueManager(ConnectionFactory connectionFactory, RabbitMQUserSettings userSettings, TradeExchangeCreator tradeExchangeCreator)

        {
            _connectionFactory = connectionFactory;
            _userSettings = userSettings;
            _queueConnections = new List<QueueConnection>();
        }

        public void Subscribe(Exchange exchange, MessageFilter messageFilter, ISubscriber subscriber)
        {
            var routingKeys = messageFilter?.Filters.Select(x=> $"{x.Category??"*"}.{x.Item ?? "*"}.*").ToList();


            var queue = new Queue(_userSettings.Author,exchange.Name(),routingKeys);
            var queueConnection = new QueueConnection(new ConnectionWrapper(_connectionFactory),queue);
            _queueConnections.Add(queueConnection);

            queueConnection.StartListening(subscriber);
        }
    }
}
