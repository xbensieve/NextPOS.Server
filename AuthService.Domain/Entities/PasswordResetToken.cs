using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Domain.Entities
{
    public class PasswordResetToken
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? UsedAt { get; set; }
        public virtual Employee Employee { get; set; } = null!;
    }
}
