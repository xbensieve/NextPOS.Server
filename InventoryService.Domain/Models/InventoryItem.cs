namespace InventoryService.Domain.Models
{
    public class InventoryItem
    {
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
