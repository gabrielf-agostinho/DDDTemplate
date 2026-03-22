using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;

namespace DDDTemplate.API.Configurations;

public static class HealthCheckConfig
{
  private static void AddApiCheck(IHealthChecksBuilder healthChecksBuilder)
  {
    healthChecksBuilder.AddCheck(
      "self",
      () => HealthCheckResult.Healthy(),
      tags: ["live"]
    );
  }

  private static void AddPostgresCheck(IHealthChecksBuilder healthChecksBuilder, string connectionString)
  {
    healthChecksBuilder.AddNpgSql(
      connectionString,
      name: "Posgres",
      tags: ["ready"]
    );
  }

  public static void AddHealthCheckConfiguration(this IServiceCollection services, string connectionString)
  {
    var healthChecksBuilder = services.AddHealthChecks();
    AddApiCheck(healthChecksBuilder);
    AddPostgresCheck(healthChecksBuilder, connectionString);
  }

  public static void AddHealthCheckConfiguration(this IServiceCollection services)
  {
    var healthChecksBuilder = services.AddHealthChecks();
    AddApiCheck(healthChecksBuilder);
  }

  public static void MapHealthCheckConfiguration(this IEndpointRouteBuilder endpoints)
  {
    endpoints.MapHealthChecks("/health");

    endpoints.MapHealthChecks("/health/live", new HealthCheckOptions
    {
      Predicate = x => x.Tags.Contains("live")
    });

    endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions
    {
      Predicate = x => x.Tags.Contains("ready"),
      ResponseWriter = async (context, report) =>
      {
        context.Response.ContentType = "application/json";

        var response = new
        {
          status = report.Status.ToString(),
          totalDuration = report.TotalDuration.TotalMilliseconds,
          checks = report.Entries.Select(x => new
          {
            name = x.Key,
            status = x.Value.Status.ToString(),
            error = x.Value.Exception?.Message,
            duration = x.Value.Duration.TotalMilliseconds
          })
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
      }
    });
  }
}