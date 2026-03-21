namespace DDDTemplate.Application.Interfaces.Configurations;

public interface ITokenConfig
{
  string Description { get; }
  string Secret { get; }
  ITokenLifetimeConfig Lifetime { get; }
  ITokenValidationConfig Validation { get; }
}

public interface ITokenLifetimeConfig
{
  TimeSpan AccessTokenExpiration { get; }
  TimeSpan RefreshTokenExpiration { get; }
}

public interface ITokenValidationConfig
{
  string? Issuer { get; }
  string? Audience { get; }
  bool ValidateLifetime { get; }
  bool ValidateSigningKey { get; }
}