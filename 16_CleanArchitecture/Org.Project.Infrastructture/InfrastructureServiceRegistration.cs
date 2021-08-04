using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.Project.Application.Contracts.Infrastructure;
using Org.Project.Application.Models.Mail;
using Org.Project.Infrastructture.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Project.Infrastructture
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // @ Register configurations for leveraging options pattern
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            //@ Register transient : created each time they're requested from the service container
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
