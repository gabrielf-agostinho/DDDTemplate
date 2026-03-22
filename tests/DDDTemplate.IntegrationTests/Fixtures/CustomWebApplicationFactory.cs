using DDDTemplate.Infrastructure.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDDTemplate.IntegrationTests.Fixtures;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.UseEnvironment("Testing");
    builder.ConfigureServices(ConfigureServices);
  }

  private static void ConfigureServices(IServiceCollection services)
  {
    var descriptors = services
        .Where(d =>
            d.ServiceType == typeof(DbContextOptions<DatabaseContext>) ||
            d.ServiceType == typeof(DatabaseContext))
        .ToList();

    foreach (var descriptor in descriptors)
      services.Remove(descriptor);

    var connection = new SqliteConnection("DataSource=:memory:");
    connection.Open();

    services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connection));

    var sp = services.BuildServiceProvider();

    using var scope = sp.CreateScope();

    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
  }
}