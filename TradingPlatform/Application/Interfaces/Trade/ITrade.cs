using Application.Commands.Trade.Buy;
using Application.Commands.Trade.Sell;

namespace Application.Interfaces.Trade
{
    public interface ITrade
    {

        void Buy(BuyRequest request);
        void Sell(SellRequest request);
    }
}
