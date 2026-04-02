using DDDTemplate.Domain.Entities;
using DDDTemplate.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDTemplate.Infrastructure.Mappings;

public class UserMap : CommonMap<User, Guid>
{
  public override void Configure(EntityTypeBuilder<User> builder)
  {
    base.Configure(builder);
    builder.Property(c => c.Name).IsRequired();
    builder.Property(c => c.Email).IsRequired();
    builder.Property(c => c.Password).IsRequired();

    builder.HasIndex(c => c.Email).IsUnique();

    builder.HasMany(c => c.UserModules).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);
  }
}