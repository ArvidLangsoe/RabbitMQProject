using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.TradeGateway;

namespace TradingPlatform.Tasks
{

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
                var externalPublisher = scope.ServiceProvider.GetRequiredService<Publisher>();
            }
        }
    }
}
