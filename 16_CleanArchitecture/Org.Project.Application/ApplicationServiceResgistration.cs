using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Org.Project.Application
{
    public static class ApplicationServiceResgistration
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
