using OrderService.Domain.Entities;
using OrderService.Domain.Events;
using OrderService.Infrastructure.Interfaces;

namespace OrderService.Application.Services
{
    public class OrderService
    {
        private readonly IMessagePublisher _messagePublisher;
        public OrderService(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        public void CreateMockOrder()
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                TotalAmount = 100_000_000,
                TaxAmount = 0,
                DiscountAmount = 0,
                FinalAmount = 100_000_000,
                OrderStatus = Domain.Enums.OrderStatus.Pending,
                PaymentMethod = Domain.Enums.PaymentMethod.Cash,
                OrderItems = null,
                Refunds = null,
            };

            var evt = new OrderCreatedEvent
            {
                OrderId = order.Id,
                ProductId = "P123",
                Quantity = 1
            };

            _messagePublisher.Publish(evt);
        }
    }
}
