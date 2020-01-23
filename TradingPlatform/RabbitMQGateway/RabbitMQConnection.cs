using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQGateway
{
    public class RabbitMQConnection
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQConnection(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            Connect();
        }

        public IModel Channel
        {
            get
            {
                if (!_connection.IsOpen|| _channel.IsClosed)
                { 
                    Reconnect();
                }
                return _channel;
            }
        }

        public void Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Reconnect()
        {
            if (_channel.IsOpen)
            { 
                _channel.Close();
            }

            if (_connection.IsOpen)
            {
                _connection.Close();
            }

            Connect();
        }
    }
}
