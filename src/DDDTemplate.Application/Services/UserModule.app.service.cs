using DDDTemplate.Application.DTOs;
using DDDTemplate.Application.Interfaces;
using DDDTemplate.Application.Services.Base;
using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;
using DDDTemplate.Domain.Interfaces.Services;
using Mapster;

namespace DDDTemplate.Application.Services;

public class UserModuleAppService(IUserModuleService userModuleService) : BaseAppService<UserModule, int, UserModuleGetDTO, UserModulePostDTO, UserModulePutDTO>(userModuleService), IUserModuleAppService
{
  protected readonly IUserModuleService UserModuleService = userModuleService;

  public IEnumerable<ModuleGetDTO> GetByCurrentUser() => UserModuleService.GetByCurrentUser().Adapt<IEnumerable<ModuleGetDTO>>();

  public bool HasModuleAccess(EModules module) => UserModuleService.HasModuleAccess(module);

  public bool HasModuleAccessWithMethod(EModules module, EMethods method)
  {
    return method switch
    {
      EMethods.GET => HasModuleAccess(module),
      EMethods.POST => UserModuleService.CanInsert(module),
      EMethods.PUT => UserModuleService.CanUpdate(module),
      EMethods.PATCH => UserModuleService.CanUpdate(module),
      EMethods.DELETE => UserModuleService.CanDelete(module),
      _ => false,
    };
  }
}