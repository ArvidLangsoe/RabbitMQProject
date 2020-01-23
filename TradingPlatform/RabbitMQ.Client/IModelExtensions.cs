using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RabbitMQ.Client.Extensions 
{
    public static class ModelExtensions
    {
        public static void BasicPublish(this IModel channel, string exchangeName, object body, string routingKey)
        {
            string messageSerialised = JsonConvert.SerializeObject(body);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(messageSerialised);

            channel.BasicPublish(exchangeName, routingKey, false, null, messageBodyBytes);



        }
    }
}
