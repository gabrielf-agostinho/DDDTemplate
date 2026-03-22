using System.Net.Http.Json;
using DDDTemplate.IntegrationTests.Fixtures;

namespace DDDTemplate.IntegrationTests.API.Users;

public class CreateUserDuplicateEmailTest(CustomWebApplicationFactory<Program> factory) : IntegrationTestsBase(factory)
{
  [Fact]
  public async Task Should_Not_Create_User_With_Duplicate_Email()
  {
    var dto = new
    {
      name = "Gabriel",
      email = "duplicate@email.com",
      password = "123456"
    };

    await Client.PostAsJsonAsync("/api/v1/users", dto);

    var response = await Client.PostAsJsonAsync("/api/v1/users", dto);

    Assert.False(response.IsSuccessStatusCode);
  }
}