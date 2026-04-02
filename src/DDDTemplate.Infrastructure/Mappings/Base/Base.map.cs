using DDDTemplate.Domain.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDTemplate.Infrastructure.Mappings.Base;

public abstract class BaseMap<TEntity, TId> : IEntityTypeConfiguration<TEntity>
  where TEntity : class, IEntity<TId>
  where TId : struct
{
  public virtual void Configure(EntityTypeBuilder<TEntity> builder)
  {
    builder.HasKey(c => c.Id);
  }
}