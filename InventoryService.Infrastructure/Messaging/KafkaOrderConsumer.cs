using Confluent.Kafka;
using InventoryService.Domain.Events;
using InventoryService.Infrastructure.Interfaces;
using System.Text.Json;

namespace InventoryService.Infrastructure.Messaging
{
    public class KafkaOrderConsumer
    {
        private readonly IInventoryService _inventoryService;

        public KafkaOrderConsumer(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void Start()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "inventory-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("order-created-topic");

            Console.WriteLine("[DEBUG] InventoryService listening Kafka topic...");

            while (true)
            {
                var cr = consumer.Consume();
                var evt = JsonSerializer.Deserialize<OrderCreatedEvent>(cr.Message.Value);
                Console.WriteLine($"[DEBUG] Receive from Kafka: {evt.ProductId} - Qty: {evt.Quantity}");
                _inventoryService.HandleOrderCreated(evt);
            }
        }
    }
}
