using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Application.Extensions
{
    // A static class to group extension methods for setting up dependency injection (DI) in the application layer.
    public static class ApplicationDIRegistration
    {
        // This is an extension method that allows us to register application-level services into the DI container.
        // It's called on IServiceCollection, which is the built-in container for ASP.NET Core.
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registers AutoMapper and tells it to scan the current assembly (i.e., this project)
            // for mapping profiles (classes that inherit from AutoMapper.Profile).
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Registers MediatR and tells it to scan the current assembly for MediatR handlers 
            // (like command/query handlers in CQRS).
            services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Returns the updated IServiceCollection so it can be chained with other registrations.
            return services;
        }
    }

}
