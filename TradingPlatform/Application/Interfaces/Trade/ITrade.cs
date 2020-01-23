using Domain;

namespace Application.Interfaces.Trade
{
    public interface ITrade
    {

        void Buy(BuyOffer offer);
        void Sell(SellOffer offer);
    }
}
