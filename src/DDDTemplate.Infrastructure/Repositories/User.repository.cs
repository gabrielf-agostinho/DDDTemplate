using Microsoft.EntityFrameworkCore;
using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Infrastructure.Contexts;
using DDDTemplate.Infrastructure.Repositories.Base;

namespace DDDTemplate.Infrastructure.Repositories;

public class UserRepository(DatabaseContext databaseContext) : BaseRepository<User, Guid>(databaseContext), IUserRepository
{
  public User GetByEmailAndPassword(string email, string password)
  {
    return DatabaseContext
      .Set<User>()
      .AsNoTracking()
      .Where(x => x.Email == email && x.Password == password)
      .FirstOrDefault()!;
  }

  public bool IsEmailRegistered(string email)
  {
    return DatabaseContext
      .Set<User>()
      .AsNoTracking()
      .Where(x => x.Email == email)
      .Any();
  }

  public void UpdateRefreshToken(Guid userId, string refreshToken, TimeSpan refreshTokenExpiration)
  {
    DatabaseContext
      .Set<User>()
      .Where(x => x.Id == userId)
      .ExecuteUpdate(x => x
        .SetProperty(c => c.RefreshToken, refreshToken)
        .SetProperty(c => c.RefreshTokenExpiration, DateTime.UtcNow.Add(refreshTokenExpiration))
      );
  }

  public void UpdatePassword(Guid userId, string password)
  {
    DatabaseContext
      .Set<User>()
      .Where(x => x.Id == userId)
      .ExecuteUpdate(x => x
        .SetProperty(c => c.Password, password)
      );
  }
}