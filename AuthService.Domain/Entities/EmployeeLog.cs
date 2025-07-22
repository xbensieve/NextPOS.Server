using AuthService.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Domain.Entities
{
    public class EmployeeLog : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Action { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
    }
}
