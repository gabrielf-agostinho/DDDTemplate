using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Enums;
using DDDTemplate.Infrastructure.Mappings.Base;
using DDDTemplate.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDTemplate.Infrastructure.Mappings;

public class ModuleMap : BaseMap<Module, EModules>
{
  public override void Configure(EntityTypeBuilder<Module> builder)
  {
    base.Configure(builder);
    builder.Property(c => c.IsActive).HasDefaultValue(true);
    builder.Property(c => c.Label).IsRequired();
    
    builder.HasMany(c => c.Items).WithOne().HasForeignKey(c => c.ParentId);
    builder.HasData(ModuleSeed.Seed());
  }
}