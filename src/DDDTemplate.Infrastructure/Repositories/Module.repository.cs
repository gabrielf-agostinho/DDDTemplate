using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Infrastructure.Contexts;
using DDDTemplate.Infrastructure.Repositories.Base;

namespace DDDTemplate.Infrastructure.Repositories;

public class ModuleRepository(DatabaseContext databaseContext) : BaseRepository<Module, EModules>(databaseContext), IModuleRepository
{

}