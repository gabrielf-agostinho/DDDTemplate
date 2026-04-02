using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories.Base;

namespace DDDTemplate.Domain.Interfaces.Repositories;

public interface IUserModuleRepository : IBaseRepository<UserModule, int>
{
  IEnumerable<Module> GetByUser(Guid userId);
}