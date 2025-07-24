namespace OrderService.Domain.Events
{
    public class OrderCreatedEvent
    {
        public Guid OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
