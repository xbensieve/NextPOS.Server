using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLog> EmployeesLogs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Role>()
                .HasData(
                    new Role
                    {
                        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                        Name = "Admin",
                        Permissions =
                            "auth.*,employee.*,product.*,inventory.*,customer.*,order.*,payment.*,report.*",
                        CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)

                    },
                    new Role
                    {
                        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                        Name = "Manager",
                        Permissions =
                            "product.view,product.update,inventory.view,order.view,report.sales",
                        CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new Role
                    {
                        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                        Name = "Cashier",
                        Permissions = "order.create,order.cancel,payment.process,customer.view",
                        CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new Role
                    {
                        Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                        Name = "Staff",
                        Permissions = "product.view,inventory.import,customer.create",
                        CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    }
                );
        }
    }
}
