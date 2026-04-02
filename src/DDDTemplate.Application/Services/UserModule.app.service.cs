using DDDTemplate.Application.DTOs;
using DDDTemplate.Application.Interfaces;
using DDDTemplate.Application.Services.Base;
using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Services;
using Mapster;

namespace DDDTemplate.Application.Services;

public class UserModuleAppService(IUserModuleService userModuleService) : BaseAppService<UserModule, int, UserModuleGetDTO, UserModulePostDTO, UserModulePutDTO>(userModuleService), IUserModuleAppService
{
  protected readonly IUserModuleService UserModuleService = userModuleService;

  public IEnumerable<ModuleGetDTO> GetByCurrentUser() => UserModuleService.GetByCurrentUser().Adapt<IEnumerable<ModuleGetDTO>>();
}