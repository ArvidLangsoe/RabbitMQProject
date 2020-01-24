using Application.Commands.Trade.Models;

namespace Application.Commands.Trade.Sell
{
    public class SellRequest : TradeRequest
    {
        public double MinPrice { get; set; }
    }
}
