using System;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace RabbitMQ.TradeGateway.Util
{
    public class RabbitMQSettings
    {
        public string Username { get; set; } = ConnectionFactory.DefaultUser;
        public string Password { get; set; } = ConnectionFactory.DefaultPass;
        public string VirtualHost { get; set; } = ConnectionFactory.DefaultVHost;
        public string HostName { get; set; } = "localhost";
    }

    public static class RabbitMqStartupExtensions
    {
        public static void AddRabbitMqConnectionWrapper(this IServiceCollection services, Action<RabbitMQSettings> setupAction)
        {
            var settings = new RabbitMQSettings();
            setupAction(settings);
            var factory = new ConnectionFactory
            {
                UserName = settings.Username,
                Password = settings.Password,
                VirtualHost = settings.VirtualHost,
                HostName = settings.HostName
            };

            services.AddSingleton(settings);
            services.AddSingleton<ConnectionFactory>(factory);
            services.AddScoped<ConnectionWrapper>();
        }
    }
}
