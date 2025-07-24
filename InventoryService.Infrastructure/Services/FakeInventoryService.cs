using InventoryService.Domain.Events;
using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Interfaces;
using System.Collections.Concurrent;

namespace InventoryService.Infrastructure.Services
{
    public class FakeInventoryService : IInventoryService
    {
        private static readonly ConcurrentDictionary<string, InventoryItem> _inventory = new();
        public FakeInventoryService()
        {
            _inventory.TryAdd("P123", new InventoryItem { ProductId = "P123", Quantity = 10 });
            _inventory.TryAdd("P456", new InventoryItem { ProductId = "P456", Quantity = 10 });

        }
        public void HandleOrderCreated(OrderCreatedEvent evt)
        {
            if (_inventory.TryGetValue(evt.ProductId, out var item))
            {
                item.Quantity -= evt.Quantity;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[DEBUG] Inventory Delete: {evt.ProductId} - {evt.Quantity} product");
                Console.WriteLine($"[DEBUG] Inventory Rest: {item.Quantity}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[DEBUG] Product not found: {evt.ProductId}");
            }
        }
    }
}
