using DoctorAppointmentSystem.WebApi.Model.ReturnModels;
using System.Net;

namespace DoctorAppointmentSystem.WebApi.Services.Abstract;

public interface IEntityService<TEntity, TId, TEntityDto, TEntityDto2,TEntityDto3>
{
    ReturnModel<IQueryable<TEntityDto>> GetAll();
    ReturnModel<IQueryable<TEntityDto>> GetById(TId id);
    ReturnModel<IQueryable<TEntityDto>> Add(TEntityDto2 dto);
    ReturnModel<IQueryable<TEntityDto>> Update(TEntityDto3 entity);
    ReturnModel<IQueryable<TEntityDto>> Delete(TId id);
    ReturnModel<IQueryable<TEntityDto>> ReturnModelOfSuccess(IQueryable<TEntityDto> entity, string message);
    ReturnModel<IQueryable<TEntityDto>> ReturnModelOfException(Exception ex);
    HttpStatusCode GetExceptionStatusCode(Exception ex);
    IQueryable<TEntityDto> ConvertIntoQueryable(TEntityDto entity);
}
