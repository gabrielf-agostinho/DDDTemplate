using System.Net.Http.Json;
using System.Text.Json;
using DDDTemplate.IntegrationTests.Fixtures;

namespace DDDTemplate.IntegrationTests.API.Users;

public class CreateUserTest(CustomWebApplicationFactory<Program> factory) : IntegrationTestsBase(factory)
{
  [Fact]
  public async Task Should_Create_User()
  {
    var dto = new
    {
      name = "Gabriel",
      email = "gabriel@email.com",
      password = "123456"
    };

    var response = await Client.PostAsJsonAsync("/api/v1/users", dto);

    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadFromJsonAsync<JsonElement>();

    Assert.NotEqual(Guid.Empty, result.GetProperty("id").GetGuid());
  }
}