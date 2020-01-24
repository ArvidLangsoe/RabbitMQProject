using System;
using System.Collections.Generic;
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
            RoutingKeys = routingKeys ?? new List<string>(new string[]{"#"});
        }

    }
}
