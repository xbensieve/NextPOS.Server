using InventoryService.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace InventoryService.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string ContactEmail { get; set; }
        [MaxLength(20)]
        public string ContactPhone { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
