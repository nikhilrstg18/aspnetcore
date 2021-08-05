using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Org.Project.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace Org.Project.Api.IntegrationTests.Base
{
    public class CustomWebApplicationFactory<TStartup>
                : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<OrgDbContext>(options =>
                {
                    options.UseInMemoryDatabase("OrgDbContextTest");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<OrgDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    context.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                };
            });
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
    }
}
