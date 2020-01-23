using RabbitMQ.TradeGateway.Util;

namespace RabbitMQ.TradeGateway.Setup
{
    public abstract class RabbitMQInitializer
    {
        protected ConnectionWrapper _connection;
        public string Author { get; }

        protected RabbitMQInitializer(ConnectionWrapper connectionWrapper, InitSettings settings)
        {
            _connection = connectionWrapper;
            Author = settings.Author;
            //TODO: Figure out if this is a problem.
            DeclareExchanges(Exchange.Sell, Exchange.Buy, Exchange.Info);
            IsInitialized = true;
        }

        public bool IsInitialized { get;}

        protected abstract void DeclareExchanges(params string[] exchangeNames);

    }
}
