using DDDTemplate.Domain.Helpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DDDTemplate.API.Helpers;

public static class DTOValidator
{
  public static void CheckForErrors<TDTO>(ViewDataDictionary ViewData)
  {
    List<string>? errors = ViewData.ModelState.Values
              .SelectMany(modelState => modelState.Errors)
              .Select(error => error.ErrorMessage)
              .ToList();

    if (errors.Count > 0)
      throw new CustomExceptions.InvalidDTOException(typeof(TDTO).Name, string.Join("; ", errors));
  }
}
