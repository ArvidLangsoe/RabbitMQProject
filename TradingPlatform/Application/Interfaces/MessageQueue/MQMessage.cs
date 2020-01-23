using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.MessageQueue
{
    public class MQMessage
    {
        public string ExchangeName { get; set; }
        public string Category { get; set; }
        public string ItemName { get; set; }
        public string Request { get; set; }
        public object Body { get; set; }

    }
}
