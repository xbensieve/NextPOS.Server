using InventoryService.Domain.Base;
using InventoryService.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Domain.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string PurchaseOrderNumber { get; set; }
        public Guid SupplierId { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal TotalAmount { get; set; }
        [Required]
        public PurchaseOrderStatus PurchaseOrderStatus { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseOrderItem> Items { get; set; }
    }
}
