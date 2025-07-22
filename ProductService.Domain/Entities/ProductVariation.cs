using ProductService.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Domain.Entities
{
    public class ProductVariation : BaseEntity
    {
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Sku { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public virtual ICollection<VariationAttribute> VariationAttributes { get; set; } = new List<VariationAttribute>();
        public virtual ICollection<VariationImage> VariationImages { get; set; } = new List<VariationImage>();
    }
}
