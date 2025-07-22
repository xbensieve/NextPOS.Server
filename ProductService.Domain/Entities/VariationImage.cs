using ProductService.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Domain.Entities
{
    public class VariationImage : BaseEntity
    {
        public Guid ProductVariationId { get; set; }
        [Required]
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        [Required]
        public string PublicId { get; set; }
        public bool IsPrimary { get; set; } = false;
        [ForeignKey(nameof(ProductVariationId))]
        public virtual ProductVariation ProductVariation { get; set; }
    }
}
