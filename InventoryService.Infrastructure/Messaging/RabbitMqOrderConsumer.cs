using InventoryService.Domain.Events;
using InventoryService.Infrastructure.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;
using System.Text.Json;

namespace InventoryService.Infrastructure.Messaging
{
    public class RabbitMqOrderConsumer
    {
        private readonly IInventoryService _inventoryService;
        private readonly string _hostName = "localhost";
        private readonly int _port = 5672;
        private readonly string _queueName = "order_created_queue";
        private IConnection _connection;
        private IModel _channel;
        private readonly int _retryCount = 5;
        private readonly TimeSpan _retryDelay = TimeSpan.FromSeconds(5);

        public RabbitMqOrderConsumer(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        public void Start()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                Port = _port,
                UserName = "guest",
                Password = "guest"
            };

            for (int attempt = 1; attempt <= _retryCount; attempt++)
            {
                try
                {
                    // Create connection and channel
                    _connection = factory.CreateConnection();
                    _channel = _connection.CreateModel();

                    // Declare queue
                    _channel.QueueDeclare(queue: _queueName,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(_channel);
                    consumer.Received += (model, ea) =>
                    {
                        try
                        {
                            var body = ea.Body.ToArray();
                            var json = Encoding.UTF8.GetString(body);
                            var orderEvent = JsonSerializer.Deserialize<OrderCreatedEvent>(json);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"[DEBUG] Received order from OrderService: {orderEvent.ProductId} - Qty: {orderEvent.Quantity}");

                            _inventoryService.HandleOrderCreated(orderEvent);
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[DEBUG] Error processing message: {ex.Message}");
                        }
                    };

                    _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[DEBUG] InventoryService is listening to RabbitMQ...");
                    break;
                }
                catch (BrokerUnreachableException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[DEBUG] Connection attempt {attempt} failed: {ex.Message}");
                    if (attempt == _retryCount)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[DEBUG] Max retry attempts reached. Could not connect to RabbitMQ.");
                        throw;
                    }
                    Thread.Sleep(_retryDelay);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[DEBUG] Unexpected error: {ex.Message}");
                    throw;
                }
            }
        }

        public void Stop()
        {
            try
            {
                _channel?.Close();
                _connection?.Close();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[DEBUG] RabbitMQ consumer stopped.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[DEBUG] Error stopping RabbitMQ consumer: {ex.Message}");
            }
            finally
            {
                _channel?.Dispose();
                _connection?.Dispose();
            }
        }
    }
}