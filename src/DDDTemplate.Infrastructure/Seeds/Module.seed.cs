using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;

namespace DDDTemplate.Infrastructure.Seeds;

public static class ModuleSeed
{
  public static Module[] Seed()
  {
    return [
      Users(),
    ];
  }

  private static Module Users()
  {
    return new Module
    {
      Id = (int)EModules.USERS,
      Label = "Usuários",
    };
  }
}