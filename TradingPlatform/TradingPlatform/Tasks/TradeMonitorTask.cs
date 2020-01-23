using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.MessageQueue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQGateway;

namespace TradingPlatform.Tasks
{


    public class TestMessage
    {
        public string Property { get; set; } = "Hello my name is";

    }


    public class TradeMonitorTask : BackgroundService
    {
        public TradeMonitorTask(IServiceProvider services)
        {
            Services = services;
        }

        public IServiceProvider Services { get; }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = Services.CreateScope())
            {
                var externalPublisher = scope.ServiceProvider.GetRequiredService<IPublish>();


                var message = new MQMessage()
                {
                    Category = "fruit",
                    ItemName = "banana",
                    Request = "sell",
                    Body = new TestMessage(),
                    ExchangeName = ExchangeInfo.Sell
                };
                externalPublisher.Publish(message);
            }
        }
    }
}
