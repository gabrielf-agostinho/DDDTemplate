using DDDTemplate.API.Controllers.Base;
using DDDTemplate.API.Helpers;
using DDDTemplate.Application.DTOs;
using DDDTemplate.Application.Interfaces;
using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DDDTemplate.API.Controllers;

public class UserModulesController(IUserModuleAppService userModuleAppService, IConfiguration configuration) : BaseController<UserModule, int, UserModuleGetDTO, UserModulePostDTO, UserModulePutDTO>(userModuleAppService, configuration)
{
  protected readonly IUserModuleAppService UserModuleAppService = userModuleAppService;

  [HttpGet]
  [Route("get-by-current-user")]
  public virtual IActionResult GetByCurrentUser()
  {
    return new Response(EResponseCodes.OK, UserModuleAppService.GetByCurrentUser());
  }

  [HttpGet]
  [Route("has-module-access/{module}")]
  public virtual IActionResult HasModuleAccess(EModules module)
  {
    return new Response(EResponseCodes.OK, UserModuleAppService.HasModuleAccess(module));
  }
}