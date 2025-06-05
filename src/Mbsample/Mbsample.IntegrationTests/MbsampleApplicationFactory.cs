using Mbsample.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mbsample.IntegrationTests;

public class MbsampleApplicationFactory : Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Replace production DbContext with in-memory
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<CustomerDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });

            // Optional: Seed test data
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
            db.Database.EnsureCreated();
        });
    }
}
