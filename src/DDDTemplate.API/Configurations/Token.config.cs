using System.Text;
using DDDTemplate.Application.Interfaces.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace DDDTemplate.API.Configurations;

public record TokenConfig : ITokenConfig
{
  public string Description { get; init; } = default!;
  public string Secret { get; init; } = default!;
  public TokenLifetimeConfig Lifetime { get; init; } = new();
  public TokenValidationConfig Validation { get; init; } = new();

  ITokenLifetimeConfig ITokenConfig.Lifetime => Lifetime;
  ITokenValidationConfig ITokenConfig.Validation => Validation;
}

public record TokenLifetimeConfig : ITokenLifetimeConfig
{
  public TimeSpan AccessTokenExpiration { get; init; }
  public TimeSpan RefreshTokenExpiration { get; init; }
}

public record TokenValidationConfig : ITokenValidationConfig
{
  public string? Issuer { get; init; }
  public string? Audience { get; init; }
  public bool ValidateLifetime { get; init; }
  public bool ValidateSigningKey { get; init; }
}

public static class TokenConfigurator
{
  public static ITokenConfig ReadTokenConfig(this IConfiguration configuration)
  {
    var tokenConfig = new TokenConfig();
    configuration.GetSection("JWTConfig").Bind(tokenConfig);
    return tokenConfig;
  }

  public static void ConfigureJWT(this IServiceCollection services, ITokenConfig tokenConfig)
  {
    services.AddSingleton(tokenConfig);
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.Secret));

    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = tokenConfig.Description;
      options.DefaultChallengeScheme = tokenConfig.Description;
    })
    .AddJwtBearer(tokenConfig.Description, options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = tokenConfig.Validation.ValidateSigningKey,
        IssuerSigningKey = key,

        ValidateIssuer = !string.IsNullOrWhiteSpace(tokenConfig.Validation.Issuer),
        ValidIssuer = tokenConfig.Validation.Issuer,

        ValidateAudience = !string.IsNullOrWhiteSpace(tokenConfig.Validation.Audience),
        ValidAudience = tokenConfig.Validation.Audience,

        ValidateLifetime = tokenConfig.Validation.ValidateLifetime,

        ClockSkew = TimeSpan.Zero
      };
    });
  }
}