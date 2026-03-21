using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories.Base;

namespace DDDTemplate.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User, Guid>
{
  bool IsEmailRegistered(string email);
  User GetByEmailAndPassword(string email, string password);
  void UpdateRefreshToken(Guid userId, string refreshToken, TimeSpan refreshTokenExpiration);
  void UpdatePassword(Guid userId, string password);
}