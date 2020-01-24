using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.TradeGateway.Setup;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway
{
 
    //TODO: Better name?
    public class QueueManager
    {
        private readonly ConnectionFactory _connectionFactory;


        public QueueManager(ConnectionFactory connectionFactory, RabbitMQUserSettings userSettings, ExchangeCreator exchangeCreator)
        {
            _connectionFactory = connectionFactory;

        }

    }
}
