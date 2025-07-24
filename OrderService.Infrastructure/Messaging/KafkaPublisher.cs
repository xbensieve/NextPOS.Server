using Confluent.Kafka;
using OrderService.Domain.Events;
using OrderService.Infrastructure.Interfaces;
using System.Text.Json;

namespace OrderService.Infrastructure.Messaging
{
    public class KafkaPublisher : IMessagePublisher
    {
        private readonly IProducer<Null, string> _producer;
        private const string Topic = "order-created-topic";

        public KafkaPublisher()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public void Publish(OrderCreatedEvent evt)
        {
            var json = JsonSerializer.Serialize(evt);
            _producer.Produce(Topic, new Message<Null, string> { Value = json });
            Console.WriteLine("✅ [Kafka] Đã publish OrderCreatedEvent.");
        }
    }
}
