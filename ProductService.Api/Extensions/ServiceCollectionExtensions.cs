using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application;
using ProductService.Application.Behaviors;
using ProductService.Domain.Interfaces.Categories;
using ProductService.Infrastructure.Data;
using ProductService.Infrastructure.Repositories.Categories;

namespace ProductService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            services.AddValidatorsFromAssemblyContaining<AssemblyReference>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ProductDbContext>
                (options => options.UseMySql(config.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 36))));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
