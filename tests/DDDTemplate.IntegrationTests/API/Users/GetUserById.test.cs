using System.Net.Http.Json;
using System.Text.Json;
using DDDTemplate.IntegrationTests.Fixtures;

namespace DDDTemplate.IntegrationTests.API.Users;

public class GetUserByIdTest(CustomWebApplicationFactory<Program> factory) : IntegrationTestsBase(factory)
{
  [Fact]
  public async Task Should_Get_User_By_Id()
  {
    string name = "Gabriel";
    string email = "gabriel_get@email.com";

    var createDto = new
    {
      name,
      email,
      password = "123456"
    };

    var createResponse = await Client.PostAsJsonAsync("/api/v1/users", createDto);
    var createdUser = await createResponse.Content.ReadFromJsonAsync<JsonElement>();

    var id = createdUser.GetProperty("id").GetGuid();

    var response = await Client.GetAsync($"/api/v1/users/{id}");

    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadFromJsonAsync<JsonElement>();

    Assert.Equal(id, result.GetProperty("id").GetGuid());
    Assert.Equal(name, result.GetProperty("name").GetString());
    Assert.Equal(email, result.GetProperty("email").GetString());
  }
}