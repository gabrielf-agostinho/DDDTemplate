using DDDTemplate.Application.Utils;
using DDDTemplate.Domain.Helpers;

namespace DDDTemplate.Application.DTOs;

public record AuthDTO
{
  private string? _Password;

  public required string Email { get; set; }
  public required string Password
  {
    get => _Password!;
    set
    {
      if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        throw new CustomExceptions.InvalidDTOException(typeof(AuthDTO).Name, "Password is null or empty");

      _Password = HashGenerator.GenerateSHA256(value);
    }
  }
}

public record PasswordResetDTO
{
  private string? _OldPassword;
  private string? _NewPassword;

  public required string OldPassword
  {
    get => _OldPassword!;
    set
    {
      if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        throw new CustomExceptions.InvalidDTOException(typeof(PasswordResetDTO).Name, "Old password is null or empty");

      _OldPassword = HashGenerator.GenerateSHA256(value);
    }
  }

  public required string NewPassword
  {
    get => _NewPassword!;
    set
    {
      if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        throw new CustomExceptions.InvalidDTOException(typeof(PasswordResetDTO).Name, "New password is null or empty");

      _NewPassword = HashGenerator.GenerateSHA256(value);
    }
  }
}