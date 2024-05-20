using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using RabbitMQ.Client;

namespace BLL.Services
{
    public class RabbitMqService: IMessageQueue
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly IModel _channel;

        public RabbitMqService(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

            using var connection = _connectionFactory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: "userQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        }

        public void PutMessage<T>(T input, string messageType)
        {

            var messageData = new MessageQueueData<T>(input, messageType);
            var serialised = JsonSerializer.Serialize(messageData);

            //object to publish
            var body = Encoding.UTF8.GetBytes(serialised);
            _channel.BasicPublish(exchange: "", routingKey: "userQueue", basicProperties: null, body: body);

        }

        public IModel GetChannel() => _channel;

    }
}
