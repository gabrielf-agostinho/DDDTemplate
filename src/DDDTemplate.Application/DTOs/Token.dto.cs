namespace DDDTemplate.Application.DTOs;

public record TokenDTO
{
  public required string AccessToken { get; set; }
  public required DateTime CreatedAt { get; set; }
  public DateTime? ExpiresAt { get; set; }
  public string? RefreshToken { get; set; }
}