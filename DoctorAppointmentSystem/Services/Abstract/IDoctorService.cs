using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Request;
using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Response;
using DoctorAppointmentSystem.WebApi.Model;
using DoctorAppointmentSystem.WebApi.Model.Enums;
using DoctorAppointmentSystem.WebApi.Model.ReturnModels;

namespace DoctorAppointmentSystem.WebApi.Services.Abstract;

public interface IDoctorService : IEntityService< Doctor, int, DoctorResponseDto, AddDoctorRequestDto, UpdateDoctorRequestDto>
{
    public ReturnModel<IQueryable<DoctorResponseDto>> GetByBranch(string branch);
    public ReturnModel<IQueryable<DoctorResponseDto>> GetByName(string name);
    public ReturnModel<IQueryable<string>> GetPatientsByDoctor(int id);
}
