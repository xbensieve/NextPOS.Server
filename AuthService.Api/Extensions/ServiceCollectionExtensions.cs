using AuthService.Application;
using AuthService.Application.BackgroundWorker;
using AuthService.Application.Behaviors;
using AuthService.Domain.Interfaces.Email;
using AuthService.Domain.Interfaces.Employees;
using AuthService.Domain.Interfaces.JwtToken;
using AuthService.Domain.Interfaces.Password;
using AuthService.Domain.Interfaces.Roles;
using AuthService.Infrastructure.Data;
using AuthService.Infrastructure.Repositories.Employees;
using AuthService.Infrastructure.Repositories.Roles;
using AuthService.Infrastructure.Services;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace AuthService.Api.Extensions
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
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            services.AddHostedService<BackgroundWorker>();
            return services;
        }
    }
}
