using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Services.Base;

namespace DDDTemplate.Domain.Interfaces.Services;

public interface IUserService : IBaseService<User, Guid>
{
  bool IsEmailRegistered(string email);
  User GetByEmailAndPassword(string email, string password);
  void UpdateRefreshToken(Guid userId, string refreshToken, TimeSpan refreshTokenExpiration);
  void UpdatePassword(Guid userId, string password);
  void FillDefaultModules(User user);
}