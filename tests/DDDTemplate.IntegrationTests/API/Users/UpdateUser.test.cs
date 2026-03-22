using System.Net.Http.Json;
using System.Text.Json;
using DDDTemplate.IntegrationTests.Fixtures;

namespace DDDTemplate.IntegrationTests.API.Users;

public class UpdateUserTest(CustomWebApplicationFactory<Program> factory) : IntegrationTestsBase(factory)
{
  [Fact]
  public async Task Should_Update_User()
  {
    var createDto = new
    {
      name = "Gabriel",
      email = "update@email.com",
      password = "123456"
    };

    var createResponse = await Client.PostAsJsonAsync("/api/v1/users", createDto);
    var createdUser = await createResponse.Content.ReadFromJsonAsync<JsonElement>();

    var id = createdUser.GetProperty("id").GetGuid();

    var updateDto = new
    {
      name = "Gabriel Updated",
      email = "updated@email.com"
    };

    var response = await Client.PutAsJsonAsync($"/api/v1/users/{id}", updateDto);

    response.EnsureSuccessStatusCode();

    var getResponse = await Client.GetAsync($"/api/v1/users/{id}");
    var user = await getResponse.Content.ReadFromJsonAsync<JsonElement>();

    var teste = user.GetProperty("name").GetString();

    Assert.Equal("Gabriel Updated", teste);
  }
}