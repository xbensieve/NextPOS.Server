using CustomerService.Domain.Base;
using CustomerService.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService.Domain.Entities
{
    public class LoyaltyTransaction : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid? OrderId { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public LoyaltyTransactionType LoyaltyTransactionType { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
