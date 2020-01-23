using Application.Interfaces.Trade;
using Domain;
using RabbitMQ.Client.Extensions;

namespace RabbitMQ.TradeGateway
{
    public class Publisher :ITradeInform, ITrade
    {
        private readonly ConnectionWrapper _connectionWrapper;

        public Publisher(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }

        public void Inform(TradeInformation trade)
        {
            Publish(trade,"Info");
        }

        public void Buy(BuyOffer offer)
        {
            Publish(offer, "Info");
        }

        public void Sell(SellOffer offer)
        {
            Publish(offer, "Info");
        }

        private void Publish(TradeBase trade,string type)
        {
            using (var channel = _connectionWrapper.NewChannel())
            {
                channel.BasicPublish(Exchange.Info, trade, $"{trade.Category}.{trade.ItemName}.{type}");
            }

        }
    }
}
