using ProductService.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Domain.Entities
{
    public class VariationAttribute : BaseEntity
    {
        public Guid ProductVariationId { get; set; }
        [Required]
        [MaxLength(50)]
        public string AttributeName { get; set; }
        [Required]
        [MaxLength(50)]
        public string AttributeValue { get; set; }
        [ForeignKey(nameof(ProductVariationId))]
        public virtual ProductVariation ProductVariation { get; set; }
    }
}
