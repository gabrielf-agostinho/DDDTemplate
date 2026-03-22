using System.Net.Http.Json;
using System.Text.Json;
using DDDTemplate.IntegrationTests.Fixtures;

namespace DDDTemplate.IntegrationTests.API.Users;

public class GetAllUsersTest(CustomWebApplicationFactory<Program> factory) : IntegrationTestsBase(factory)
{
  [Fact]
  public async Task Should_Get_All_Users()
  {
    var dto1 = new
    {
      name = "User List",
      email = "list@email.com",
      password = "123456"
    };

    var dto2 = new
    {
      name = "User List 2",
      email = "list2@email.com",
      password = "123456"
    };

    await Client.PostAsJsonAsync("/api/v1/users", dto1);
    await Client.PostAsJsonAsync("/api/v1/users", dto2);

    var response = await Client.GetAsync("/api/v1/users");

    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadFromJsonAsync<JsonElement>();

    Assert.True(result.GetArrayLength() > 0);
  }
}