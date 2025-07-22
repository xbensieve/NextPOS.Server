using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentService.Domain.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
