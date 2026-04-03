using DDDTemplate.Domain.Enums;
using DDDTemplate.Domain.Interfaces.Entities;

namespace DDDTemplate.Domain.Entities;

public class Module : IEntity<EModules>, IActivatable
{
  public EModules Id { get; set; }
  public bool IsActive { get; set; }
  public required string Label { get; set; }
  public string? Icon { get; set; }
  public EModules? ParentId { get; set; }
  public string? RouterLink { get; set; }
  
  public ICollection<Module> Items { get; set; } = [];
}