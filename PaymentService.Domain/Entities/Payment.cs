using PaymentService.Domain.Base;
using PaymentService.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentService.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }
        public PaymentGateway PaymentGateway { get; set; }
        [Required]
        [MaxLength(255)]
        public string TransactionId { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Amount { get; set; }
        [Required]
        public PaymentStatus Status { get; set; }
    }
}
