using DDDTemplate.Application.DTOs.Base;

namespace DDDTemplate.Application.DTOs;

public record ModuleGetDTO : BaseDTO<int>
{
  public bool IsActive { get; set; }
  public required string Label { get; set; }
  public string? Icon { get; set; }
  public int? ParentId { get; set; }

  public ICollection<ModuleGetDTO> Items { get; set; } = [];
}