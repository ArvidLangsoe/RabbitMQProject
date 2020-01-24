using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway
{
    public class QueueConnection
    {
        private readonly ConnectionWrapper _connection;
        private Queue Queue { get; }

        public QueueConnection(ConnectionWrapper connection, Queue queue)
        {
            _connection = connection;
            Queue = queue;
            Declare();

        }
        
        public void Declare()
        {
            using (var channel = _connection.NewChannel())
            {
                channel.QueueDeclare(Queue.Name, true, false, false, null);

                foreach (var routingKey in Queue.RoutingKeys)
                {
                    channel.QueueBind(Queue.Name, Queue.ExchangeName, routingKey, null);
                }
            }

        }

    }
}
