using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrdersItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
