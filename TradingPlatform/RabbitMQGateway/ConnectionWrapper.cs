using RabbitMQ.Client;

namespace RabbitMQ.TradeGateway
{
    public class ConnectionWrapper
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;


        public ConnectionWrapper(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            Connect();
        }

        public IModel NewChannel()
        {
            if (!_connection.IsOpen)
            { 
                Reconnect();
            }
            return _connection.CreateModel();
        }

        public void Connect()
        {
            _connection = _connectionFactory.CreateConnection();

        }

        public void Reconnect()
        {
            if (_connection.IsOpen)
            {
                _connection.Close();
            }

            Connect();
        }
    }
}
