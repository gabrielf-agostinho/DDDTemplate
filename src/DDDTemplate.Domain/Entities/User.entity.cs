using DDDTemplate.Domain.Entities.Base;

namespace DDDTemplate.Domain.Entities;

public class User : CommonEntity<Guid>
{
  public override Guid Id { get; set; } = Guid.NewGuid();
  public required string Name { get; set; }
  public required string Email { get; set; }
  public required string Password { get; set; }
  public string? RefreshToken { get; set; }
  public DateTime? RefreshTokenExpiration { get; set; }
}