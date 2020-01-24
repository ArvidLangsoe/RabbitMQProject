using System;

namespace Application.Interfaces.Trade
{
    public enum Exchange
    {
        Sell,
        Buy,
        Info
    }

    public static class ExchangeExtension
    {
        public static string Name(this Exchange exchange)
        {
            return $"Trade.{Enum.GetName( typeof(Exchange),exchange)}";
        }


    }

}
