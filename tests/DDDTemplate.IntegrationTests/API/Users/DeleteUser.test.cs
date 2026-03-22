using System.Net.Http.Json;
using System.Text.Json;
using DDDTemplate.IntegrationTests.Fixtures;

namespace DDDTemplate.IntegrationTests.API.Users;

public class DeleteUserTest(CustomWebApplicationFactory<Program> factory) : IntegrationTestsBase(factory)
{
  [Fact]
  public async Task Should_Delete_User()
  {
    var createDto = new
    {
      name = "Gabriel",
      email = "delete@email.com",
      password = "123456"
    };

    var createResponse = await Client.PostAsJsonAsync("/api/v1/users", createDto);
    var createdUser = await createResponse.Content.ReadFromJsonAsync<JsonElement>();

    var id = createdUser.GetProperty("id").GetGuid();

    var deleteResponse = await Client.DeleteAsync($"/api/v1/users/{id}");

    deleteResponse.EnsureSuccessStatusCode();

    var getResponse = await Client.GetAsync($"/api/v1/users/{id}");

    Assert.False(getResponse.IsSuccessStatusCode);
  }
}