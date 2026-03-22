using Mapster;

namespace DDDTemplate.API.Configurations;

public static class MappingConfig
{
  public static void RegisterMappings()
  {
    var config = TypeAdapterConfig.GlobalSettings;

    config.When((srcType, destType, mapType) => srcType.Name.EndsWith("PutDTO")).Ignore("Id");
  }
}
