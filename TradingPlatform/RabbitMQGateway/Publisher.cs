using System;
using Application.Interfaces.Trade;
using Domain;
using RabbitMQ.Client;
using RabbitMQ.Client.Extensions;
using RabbitMQ.TradeGateway.Setup;
using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway
{
    public class Publisher :  ITrade, IDisposable
    {
        private readonly ConnectionWrapper _connectionWrapper;
        private string Author { get; }

        private IModel _channel;

        public Publisher(ConnectionWrapper connectionWrapper,RabbitMQUserSettings userSettings, TradeExchangeCreator tradeExchangeCreator)
        {
            _connectionWrapper = connectionWrapper;
            Author = userSettings.Author;
        }


        public void Buy(BuyRequest request)
        {
            Publish(request, Exchange.Buy, Author);
        }

        public void Sell(SellRequest request)
        {
            Publish(request, Exchange.Sell, Author);
        }

        private void Publish(TradeBase trade,Exchange exchange,string author)
        {
            if (_channel == null || _channel.IsClosed)
            {
                _channel = _connectionWrapper.NewChannel();
            }
            _channel.BasicPublish(exchange.Name(), trade, $"{trade.Category}.{trade.ItemName}.{author}");
            

        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
