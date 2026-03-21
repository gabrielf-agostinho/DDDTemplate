using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Domain.Interfaces.Services;
using DDDTemplate.Domain.Services.Base;

namespace DDDTemplate.Domain.Services;

public class UserService(IUserRepository userRepository) : BaseService<User, Guid>(userRepository), IUserService
{
  protected readonly IUserRepository UserRepository = userRepository;

  public User GetByEmailAndPassword(string email, string password) => UserRepository.GetByEmailAndPassword(email, password);

  public bool IsEmailRegistered(string email) => UserRepository.IsEmailRegistered(email);
  
  public void UpdateRefreshToken(Guid userId, string refreshToken, TimeSpan refreshTokenExpiration) => UserRepository.UpdateRefreshToken(userId, refreshToken, refreshTokenExpiration);
  
  public void UpdatePassword(Guid userId, string password) => UserRepository.UpdatePassword(userId, password);
}