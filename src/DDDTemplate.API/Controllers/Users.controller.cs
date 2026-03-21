using DDDTemplate.API.Controllers.Base;
using DDDTemplate.Application.DTOs;
using DDDTemplate.Application.Interfaces;
using DDDTemplate.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDTemplate.API.Controllers;

public class UsersController(IUserAppService userAppService, IConfiguration configuration) : BaseController<User, Guid, UserGetDTO, UserPostDTO, UserPutDTO>(userAppService, configuration)
{

  [AllowAnonymous]
  public override IActionResult Insert([FromBody] UserPostDTO dto)
  {
    return base.Insert(dto);
  }
}