using OrderService.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Domain.Entities
{
    public class Refund : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal RefundAmount { get; set; }
        [Required]
        [MaxLength(500)]
        public string Reason { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
    }
}
