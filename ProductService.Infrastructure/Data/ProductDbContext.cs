using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<VariationAttribute> VariationAttributes { get; set; }
        public DbSet<VariationImage> VariationImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
