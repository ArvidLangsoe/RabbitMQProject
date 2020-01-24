using System;
using RabbitMQ.Client;

namespace RabbitMQ.TradeGateway.Util
{
    public class ConnectionWrapper : IDisposable
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

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
