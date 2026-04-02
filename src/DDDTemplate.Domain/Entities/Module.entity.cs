using DDDTemplate.Domain.Interfaces.Entities;

namespace DDDTemplate.Domain.Entities;

public class Module : IEntity<int>, IActivatable
{
  public int Id { get; set; }
  public bool IsActive { get; set; }
  public required string Label { get; set; }
  public string? Icon { get; set; }
  public int? ParentId { get; set; }
  
  public ICollection<Module> Items { get; set; } = [];
}