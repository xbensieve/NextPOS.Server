using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedByIp { get; set; }
        public bool IsRevoked { get; set; } = false;
        public DateTime? RevokedAt { get; set; }
        public virtual Employee Employee { get; set; } = null!;
    }
}
