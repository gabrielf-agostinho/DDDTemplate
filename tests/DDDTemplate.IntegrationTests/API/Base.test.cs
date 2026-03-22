using DDDTemplate.IntegrationTests.Fixtures;
using DDDTemplate.IntegrationTests.Helpers;

namespace DDDTemplate.IntegrationTests.API;

public class IntegrationTestsBase : IClassFixture<CustomWebApplicationFactory<Program>>
{
  protected readonly HttpClient Client;

  public IntegrationTestsBase(CustomWebApplicationFactory<Program> factory)
  {
    Client = factory.CreateClient();
    AuthHelper.AuthenticateAsync(Client).GetAwaiter().GetResult();
  }
}