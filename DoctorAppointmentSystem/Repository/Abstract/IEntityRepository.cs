using DoctorAppointmentSystem.WebApi.Model;
using System.Linq.Expressions;

namespace DoctorAppointmentSystem.WebApi.Repository.Abstract;

public interface IEntityRepository<TEntity, TId, TEntityDto> where TEntity : EntityBase<TId>, new()
{
    IQueryable<TEntityDto> GetAll();
    //   IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    TEntity GetById(TId id);
    TEntityDto Add(TEntity entity);
    TEntityDto Update(TEntity entity);
    TEntityDto Delete(TId id);

}
