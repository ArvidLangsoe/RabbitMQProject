using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.TradeGateway.Setup;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway
{
    public class Queue
    {
        public string Author { get; }
        public string ExchangeName {get;}
        public IEnumerable<string> RoutingKeys { get; }
        public string Name => $"{ExchangeName}, {Author}";


        public Queue(string author, string exchangeName, IEnumerable<string> routingKeys)
        {
            Author = author;
            ExchangeName = exchangeName;
            if (routingKeys == null || !routingKeys.Any())
            {
                routingKeys = new List<string>(new string[] {"*.*.*"});
            }

            RoutingKeys = routingKeys;
        }

    }
}
