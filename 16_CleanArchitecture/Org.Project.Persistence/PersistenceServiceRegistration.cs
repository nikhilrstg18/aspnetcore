using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Project.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //@ Register Db context
            services.AddDbContext<OrgDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrgProjectConn")));

            //@ Register scoped : created once per client request (connection) and disposed at the end of request
            services
                .AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>))
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IEventRepository, EventRepository>()
                .AddScoped<IOrderRepository, OrderRepository>(); 

            return services;
        }

    }
}
