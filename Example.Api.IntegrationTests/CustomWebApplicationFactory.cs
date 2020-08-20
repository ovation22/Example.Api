using System;
using System.Linq;
using Example.Core.Entities;
using Example.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Api.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<DefaultContext>));

                services.Remove(descriptor);

                services.AddDbContextPool<DefaultContext>(options =>
                {
                    options.UseInMemoryDatabase("Default");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DefaultContext>();

                db.Database.EnsureCreated();

                InitializeDbForTests(db);
            });
        }

        private void InitializeDbForTests(DefaultContext db)
        {
            db.Users.RemoveRange(db.Users);
            db.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Steve",
                MiddleName = 'F',
                LastName = "Jobs",
                EmailAddress = "steve@jobs.com",
                Phone = "555-1212"
            });
            db.SaveChanges();
        }
    }
}