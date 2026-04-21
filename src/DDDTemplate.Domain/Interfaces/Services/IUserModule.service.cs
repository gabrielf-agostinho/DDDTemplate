using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;
using DDDTemplate.Domain.Interfaces.Services.Base;

namespace DDDTemplate.Domain.Interfaces.Services;

public interface IUserModuleService : IBaseService<UserModule, int>
{
  IEnumerable<Module> GetByCurrentUser();
  bool HasModuleAccess(EModules module);
  bool CanInsert(EModules module);
  bool CanUpdate(EModules module);
  bool CanDelete(EModules module);
}