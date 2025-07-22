using AuthService.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Permissions { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
