using Domain;

namespace Application.Interfaces.Trade
{
    public interface ITrade
    {

        void Buy(BuyRequest request);
        void Sell(SellRequest request);
    }
}
