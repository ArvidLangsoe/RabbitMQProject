using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{

    /**
     * Basic information about anything relating to trading. This means everything send over rabbitMQ
     */
    public abstract class TradeBase
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string ItemName { get; set; }

    }
}
