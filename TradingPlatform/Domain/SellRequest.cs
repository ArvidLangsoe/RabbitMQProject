using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SellRequest : TradeRequest
    {
        public double MinPrice { get; set; }
    }
}
