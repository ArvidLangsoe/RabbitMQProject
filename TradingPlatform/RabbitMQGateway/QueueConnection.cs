using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Trade;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway
{
    public class QueueConnection
    {
        private readonly ConnectionWrapper _connection;
        private IModel _channel;
        private ISubscriber _subscriber;
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

        public void StartListening(ISubscriber subscriber)
        {
            _channel= _connection.NewChannel();
            _subscriber = subscriber;
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body;
                var obj = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(body));
                _subscriber.NewMessage(obj);
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            string consumerTag = _channel.BasicConsume(Queue.Name,false,consumer);
        }
    }
}
