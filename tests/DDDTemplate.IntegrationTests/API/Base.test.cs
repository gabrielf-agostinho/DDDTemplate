using DDDTemplate.IntegrationTests.Fixtures;

namespace DDDTemplate.IntegrationTests.API;

public class IntegrationTestsBase(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  protected readonly HttpClient Client = factory.CreateClient();
}