using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Domain
{

    //Where to put these. Are they domain objects? Are they something else? They are definetly not application classes.
    public class BuyRequest : TradeRequest, IRequest
    {
        private double MaxPrice { get; set; }
    }
}
