namespace DDDTemplate.Application.Extensions;

public static class GenericUtils
{
  public static bool IsDefault<T>(T value) => EqualityComparer<T>.Default.Equals(value, default);
}