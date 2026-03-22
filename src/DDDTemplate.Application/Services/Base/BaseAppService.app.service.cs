using System.Linq.Expressions;
using Mapster;
using DDDTemplate.Application.Interfaces.Base;
using DDDTemplate.Application.Utils;
using DDDTemplate.Domain.Interfaces.Entities;
using DDDTemplate.Domain.Interfaces.Services.Base;
using DDDTemplate.Application.DTOs.Base;
using DDDTemplate.Application.Extensions;
using DDDTemplate.Domain.Helpers;

namespace DDDTemplate.Application.Services.Base;

public abstract class BaseAppService<TEntity, TId, TGetDTO, TPostDTO, TPutDTO>(IBaseService<TEntity, TId> service) : IBaseAppService<TEntity, TId, TGetDTO, TPostDTO, TPutDTO>
  where TEntity : IEntity<TId>
  where TGetDTO : BaseDTO<TId>
  where TPutDTO : BaseDTO<TId>
  where TPostDTO : class
{
  protected readonly IBaseService<TEntity, TId> Service = service;

  public virtual IEnumerable<TGetDTO> GetAll()
  {
    return Service.GetAll().Adapt<IEnumerable<TGetDTO>>();
  }

  public virtual Pagination<TGetDTO> GetPaged(
    int? skip,
    int? take,
    Expression<Func<TEntity, bool>>? filter = null,
    Expression<Func<TEntity, object>>? orderByField = null,
    string orderByDirection = "DESC"
  )
  {
    return new Pagination<TGetDTO>
    (
      total: Service.Count(filter),
      list: Service.GetAll(
        filter: filter,
        skip: skip,
        take: take,
        orderByField: orderByField,
        orderByDirection: orderByDirection
      ).Adapt<IEnumerable<TGetDTO>>()
    );
  }

  public virtual TGetDTO GetById(TId id)
  {
    return Service.GetById(id).Adapt<TGetDTO>();
  }

  public virtual TId Insert(TPostDTO dto)
  {
    return Service.Insert(dto.Adapt<TEntity>());
  }

  public virtual void Update(TId id, TPutDTO dto)
  {
    ApplicationUtils.CheckIdField<TPutDTO, TId>(dto);
    
    var entityId = (!GenericUtils.IsDefault(dto.Id) ? dto.Id : id) ?? throw new CustomExceptions.IdCannotBeNullException();
    var entity = Service.GetById(entityId) ?? throw new CustomExceptions.NotFoundException<TId>(typeof(TEntity).Name, entityId);

    dto.Adapt(entity);
    Service.Update(entity);
  }

  public virtual void Update(TPutDTO dto, TEntity entity)
  {
    ApplicationUtils.CheckIdField<TPutDTO, TId>(dto);

    Service.Update(dto.Adapt(entity));
  }

  public virtual void Delete(TId id)
  {
    TEntity entity = Service.GetById(id);

    if (entity is not null)
      Service.Delete(entity);
  }
}
