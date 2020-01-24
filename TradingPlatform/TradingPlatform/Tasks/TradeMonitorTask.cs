using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Application.Interfaces.Trade;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.TradeGateway;

namespace TradingPlatform.Tasks
{

    public class TradeMonitorTask : BackgroundService, ISubscriber
    {
        public TradeMonitorTask(IServiceProvider services)
        {
            Services = services;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = Services.CreateScope();
            var externalPublisher = scope.ServiceProvider.GetRequiredService<ITrade>();
            var queueManage = scope.ServiceProvider.GetRequiredService<QueueManager>();

            var filters = new List<Filter> {new Filter() {Category = "fruit",}};
            var messageFilter = new MessageFilter()
            {
                Filters =  filters
            };

            queueManage.Subscribe(Exchange.Sell, messageFilter, this);

            while (true)
            {
                externalPublisher.Sell(new SellOffer()
                {
                    Category = "fruit",
                    Id = Guid.NewGuid(),
                    ItemName = "banana"
                });

                externalPublisher.Sell(new SellOffer()
                {
                    Category = "tools",
                    Id = Guid.NewGuid(),
                    ItemName = "hammer"
                });

                await Task.Delay(TimeSpan.FromMilliseconds(1), stoppingToken);
            }
        }

        public void NewMessage(object trade)
        {
            var a = trade;
        }
    }
}
