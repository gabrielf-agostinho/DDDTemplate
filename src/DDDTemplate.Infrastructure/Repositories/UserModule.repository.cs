using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Infrastructure.Contexts;
using DDDTemplate.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DDDTemplate.Infrastructure.Repositories;

public class UserModuleRepository(DatabaseContext databaseContext) : BaseRepository<UserModule, int>(databaseContext), IUserModuleRepository
{
  public IEnumerable<Module> GetByUser(Guid userId)
  {
    var modulesIds = DatabaseContext
      .Set<UserModule>()
      .Where(x => x.UserId == userId)
      .AsNoTracking()
      .Select(x => x.ModuleId)
      .ToList();

    return DatabaseContext
      .Set<Module>()
      .Where(x => modulesIds.Contains(x.Id))
      .AsNoTracking()
      .ToList();
  }
}