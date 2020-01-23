using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TradeBase
    {
        public Guid Id { get; set; }


        public string Category { get; set; }
        public string ItemName { get; set; }

    }
}
