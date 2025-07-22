using AuthService.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Domain.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string EmployeeCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(500)]
        public string PasswordHash { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
        public virtual ICollection<EmployeeLog> EmployeeLogs { get; set; } = new List<EmployeeLog>();
    }
}
