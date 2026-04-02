using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Domain.Interfaces.Services;
using DDDTemplate.Domain.Services.Base;

namespace DDDTemplate.Domain.Services;

public class UserModuleService(
  ICurrentUserService currentUserService,
  IUserModuleRepository userModuleRepository
) : BaseService<UserModule, int>(userModuleRepository), IUserModuleService
{
  protected readonly ICurrentUserService CurrentUserService = currentUserService;
  protected readonly IUserModuleRepository UserModuleRepository = userModuleRepository;

  public IEnumerable<Module> GetByCurrentUser() => UserModuleRepository.GetByUser((Guid)CurrentUserService.UserId!);
}