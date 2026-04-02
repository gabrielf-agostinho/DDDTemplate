using DDDTemplate.Domain.Interfaces.Entities;

namespace DDDTemplate.Domain.Entities;

public class UserModule : IEntity<int>, IAuditable, IUserTrackable<Guid>
{
  public int Id { get; set; }
  public Guid UserId { get; set; }
  public int ModuleId { get; set; }
  public bool Insert { get; set; }
  public bool Update { get; set; }
  public bool Delete { get; set; }
  public DateTime? CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public Guid? CreatedBy { get; set; }
  public Guid? UpdatedBy { get; set; }

  public User? User { get; set; }
  public Module? Module { get; set; }
}