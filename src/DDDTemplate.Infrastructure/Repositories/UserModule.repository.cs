using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Infrastructure.Contexts;
using DDDTemplate.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DDDTemplate.Infrastructure.Repositories;

public class UserModuleRepository(DatabaseContext databaseContext) : BaseRepository<UserModule, int>(databaseContext), IUserModuleRepository
{
  public IEnumerable<EModules> GetModulesByUser(Guid userId)
  {
    return [.. DatabaseContext
      .Set<UserModule>()
      .Where(x => x.UserId == userId)
      .AsNoTracking()
      .Select(x => x.ModuleId)];
  }

  public bool CanInsert(Guid userId, EModules module)
  {
    return DatabaseContext
      .Set<UserModule>()
      .Where(x => x.UserId == userId && x.ModuleId == module)
      .AsNoTracking()
      .Select(x => x.Insert)
      .FirstOrDefault() || false;
  }

  public bool CanUpdate(Guid userId, EModules module)
  {
    return DatabaseContext
      .Set<UserModule>()
      .Where(x => x.UserId == userId && x.ModuleId == module)
      .AsNoTracking()
      .Select(x => x.Update)
      .FirstOrDefault() || false;
  }

  public bool CanDelete(Guid userId, EModules module)
  {
    return DatabaseContext
      .Set<UserModule>()
      .Where(x => x.UserId == userId && x.ModuleId == module)
      .AsNoTracking()
      .Select(x => x.Delete)
      .FirstOrDefault() || false;
  }
}