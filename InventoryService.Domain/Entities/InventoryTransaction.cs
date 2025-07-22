using InventoryService.Domain.Base;
using InventoryService.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace InventoryService.Domain.Entities
{
    public class InventoryTransaction : BaseEntity
    {
        public Guid ProductVariationId { get; set; }
        public int Quantity { get; set; }
        [Required]
        public InventoryTransactionType InventoryTransactionType { get; set; }
        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
