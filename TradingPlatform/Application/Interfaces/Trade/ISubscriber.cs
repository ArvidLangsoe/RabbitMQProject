using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Trade
{
    public interface ISubscriber
    {

        void NewMessage(object trade);

    }
}
