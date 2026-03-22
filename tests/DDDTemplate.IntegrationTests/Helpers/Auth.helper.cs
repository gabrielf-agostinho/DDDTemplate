using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace DDDTemplate.IntegrationTests.Helpers;

public static class AuthHelper
{
  public static async Task AuthenticateAsync(HttpClient client)
  {
    var email = $"test_{Guid.NewGuid()}@email.com";
    string password = "123456";

    var registerDto = new
    {
      name = "Test User",
      email,
      password
    };

    await client.PostAsJsonAsync("/api/v1/users", registerDto);

    var loginDto = new
    {
      email,
      password
    };

    var response = await client.PostAsJsonAsync("/api/v1/auth", loginDto);
    var result = await response.Content.ReadFromJsonAsync<JsonElement>();
    var token = result.GetProperty("accessToken").GetString();

    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
  }
}