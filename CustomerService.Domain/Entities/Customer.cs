using CustomerService.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace CustomerService.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string CustomerCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
        public int LoyaltyPoints { get; set; } = 0;
        public DateTime? LastLoginAt { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<LoyaltyTransaction> LoyaltyTransactions { get; set; }
    }
}
