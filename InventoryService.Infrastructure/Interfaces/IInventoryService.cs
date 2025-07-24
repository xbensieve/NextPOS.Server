using InventoryService.Domain.Events;

namespace InventoryService.Infrastructure.Interfaces
{
    public interface IInventoryService
    {
        void HandleOrderCreated(OrderCreatedEvent evt);
    }
}
