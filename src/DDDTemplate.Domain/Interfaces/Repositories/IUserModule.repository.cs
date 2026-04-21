using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;
using DDDTemplate.Domain.Interfaces.Repositories.Base;

namespace DDDTemplate.Domain.Interfaces.Repositories;

public interface IUserModuleRepository : IBaseRepository<UserModule, int>
{
  IEnumerable<EModules> GetModulesByUser(Guid userId);
  bool CanInsert(Guid userId, EModules module);
  bool CanUpdate(Guid userId, EModules module);
  bool CanDelete(Guid userId, EModules module);
}