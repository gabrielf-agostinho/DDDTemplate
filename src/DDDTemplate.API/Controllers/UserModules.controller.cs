using DDDTemplate.API.Controllers.Base;
using DDDTemplate.Application.DTOs;
using DDDTemplate.Application.Interfaces;
using DDDTemplate.Domain.Entities;

namespace DDDTemplate.API.Controllers;

public class UserModulesController(IUserModuleAppService userModuleAppService, IConfiguration configuration) : BaseController<UserModule, int, UserModuleGetDTO, UserModulePostDTO, UserModulePutDTO>(userModuleAppService, configuration)
{

}