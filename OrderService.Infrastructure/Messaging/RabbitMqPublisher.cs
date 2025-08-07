using OrderService.Domain.Events;
using OrderService.Infrastructure.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderService.Infrastructure.Messaging
{
    public class RabbitMqPublisher : IMessagePublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public RabbitMqPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "order_created_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }
        public void Publish(OrderCreatedEvent evt)
        {
            var json = JsonSerializer.Serialize(evt);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchange: "",
                                 routingKey: "order_created_queue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
