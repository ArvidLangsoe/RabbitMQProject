using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.MessageQueue;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQGateway;
using TradingPlatform.Tasks;

namespace TradingPlatform
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddRabbitMqConnection((settings) =>
            {
                //TODO: needs to come from config
                settings.Username = ConnectionFactory.DefaultUser;
                settings.Password = ConnectionFactory.DefaultPass;
                settings.HostName = "localhost";
                settings.VirtualHost = ConnectionFactory.DefaultVHost;
                settings.Exchanges = new List<string>(new string[]{ExchangeInfo.Sell,ExchangeInfo.Buy, ExchangeInfo.Info});
            });
            services.AddScoped<IPublish, RabbitMQPublisher>();
            services.AddHostedService<TradeMonitorTask>();
            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
