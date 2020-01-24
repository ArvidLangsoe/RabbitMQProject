using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Application.Interfaces.Trade
{
    public interface ISubscriber
    {

        void NewMessage(TradeBase trade);

    }
}
