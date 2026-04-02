using DDDTemplate.Application.DTOs.Base;
using DDDTemplate.Application.Interfaces.DTOs;

namespace DDDTemplate.Application.DTOs;

public record UserModuleGetDTO : BaseDTO<int>, IAuditableDTO, IUserTrackableDTO<Guid>
{
  public Guid UserId { get; set; }
  public int ModuleId { get; set; }
  public bool Insert { get; set; }
  public bool Update { get; set; }
  public bool Delete { get; set; }
  public DateTime? CreatedAt { get; init; }
  public DateTime? UpdatedAt { get; init; }
  public Guid CreatedBy { get; init; }
  public Guid UpdatedBy { get; init; }
}

public record UserModulePostDTO
{
  public Guid UserId { get; set; }
  public int ModuleId { get; set; }
  public bool Insert { get; set; }
  public bool Update { get; set; }
  public bool Delete { get; set; }
}

public record UserModulePutDTO : BaseDTO<int>
{
  public Guid UserId { get; set; }
  public int ModuleId { get; set; }
  public bool Insert { get; set; }
  public bool Update { get; set; }
  public bool Delete { get; set; }
}