using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace Application.Interfaces.Trade
{
    public interface ISubscribable
    {

        void Subscribe(Exchange exchange,MessageFilter messageFilter ,ISubscriber subscriber);

    }
}
