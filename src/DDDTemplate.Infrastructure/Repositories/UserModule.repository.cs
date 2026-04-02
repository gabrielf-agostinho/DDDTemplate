using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Infrastructure.Contexts;
using DDDTemplate.Infrastructure.Repositories.Base;

namespace DDDTemplate.Infrastructure.Repositories;

public class UserModuleRepository(DatabaseContext databaseContext) : BaseRepository<UserModule, int>(databaseContext), IUserModuleRepository
{

}