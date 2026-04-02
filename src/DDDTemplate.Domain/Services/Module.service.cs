using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Domain.Interfaces.Services;
using DDDTemplate.Domain.Services.Base;

namespace DDDTemplate.Domain.Services;

public class ModuleService(IModuleRepository moduleRepository) : BaseService<Module, int>(moduleRepository), IModuleService
{
  
}