using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Trade
{
    public class MessageFilter
    {
        public List<Filter> Filters { get; set; } = new List<Filter>();
    }


    public class Filter
    {
        public string Category { get; set; }
        public string Item { get; set; }
    }
}
