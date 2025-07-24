using OrderService.Domain.Events;

namespace OrderService.Infrastructure.Interfaces
{
    public interface IMessagePublisher
    {
        void Publish(OrderCreatedEvent evt);
    }
}
