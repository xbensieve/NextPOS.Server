using OrderService.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductVariationId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal PriceAtPurchase { get; set; }
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal DiscountAmount { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal TotalAmount { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
    }
}
