using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.MessageQueue
{
    public interface IPublish
    {
        //TODO: Add return type here?
        void Publish(MQMessage message);
        IEnumerable<string> Exchanges { get;}
    }
}
