using DDDTemplate.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DDDTemplate.API.Helpers;

public class Response(EResponseCodes code, object? data = null, string? error = null) : IActionResult
{
  public bool Success { get; } = (int)code >= 200 && (int)code <= 299;
  public object? Data { get; } = data;
  public string? Error { get; } = error;
  public EResponseCodes Code { get; } = code;

  public Response(EResponseCodes code, Exception exception) : this(code, null, exception.Message) { }

  public async Task ExecuteResultAsync(ActionContext context)
  {
    var result = new
    {
      success = Success,
      data = Data,
      error = Error,
      code = (int)Code
    };

    var objectResult = new ObjectResult(result)
    {
      StatusCode = (int)Code
    };

    await objectResult.ExecuteResultAsync(context);
  }
}
