using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Infrastructure.Extensions
{
    public static class InfrastructureDIRegistration
    {
        // This is a static class containing an extension method for registering infrastructure services into the DI container.
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            // Registers the ApplicationDbContext with the dependency injection container.
            // It uses SQL Server as the database provider and pulls the connection string named "AppConnection"
            // from your appsettings.json or environment configuration.
    service.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            configuration.GetConnectionString("AppConnection") ??
            // If the connection string is not found, throw an exception to prevent startup.
            throw new InvalidOperationException("Your connection string, 'AppConnection', was not found")
        )
    // Optional: You could enable retry logic like below if needed.
    // o => o.EnableRetryOnFailure()
    );

            // Registers the generic repository so it can be injected as IRepository<T>.
            // AddScoped means a new instance is created per HTTP request.
            // Whenever IRepository<T> is requested, the app will inject Repository<T>.
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddTransient<IEmployeeRepository, DepartmentEmployeesRepository>();


            // Returns the modified IServiceCollection so the caller can continue chaining other service registrations.
            return service;
        }

    }
}
