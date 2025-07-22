using ProductService.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public required string Sku { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal BasePrice { get; set; }
        public Guid? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public virtual ICollection<ProductVariation> ProductVariations { get; set; } = new List<ProductVariation>();
    }
}
