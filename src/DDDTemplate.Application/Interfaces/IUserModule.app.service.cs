using DDDTemplate.Application.DTOs;
using DDDTemplate.Application.Interfaces.Base;
using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;

namespace DDDTemplate.Application.Interfaces;

public interface IUserModuleAppService : IBaseAppService<UserModule, int, UserModuleGetDTO, UserModulePostDTO, UserModulePutDTO>
{
  IEnumerable<ModuleGetDTO> GetByCurrentUser();
  bool HasModuleAccess(EModules module);
}