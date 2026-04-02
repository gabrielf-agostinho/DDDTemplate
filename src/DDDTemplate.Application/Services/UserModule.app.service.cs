using DDDTemplate.Application.DTOs;
using DDDTemplate.Application.Interfaces;
using DDDTemplate.Application.Services.Base;
using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Services;

namespace DDDTemplate.Application.Services;

public class UserModuleAppService(IUserModuleService userModuleService) : BaseAppService<UserModule, int, UserModuleGetDTO, UserModulePostDTO, UserModulePutDTO>(userModuleService), IUserModuleAppService;