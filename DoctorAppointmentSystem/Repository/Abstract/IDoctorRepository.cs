using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Response;
using DoctorAppointmentSystem.WebApi.Model;
using DoctorAppointmentSystem.WebApi.Model.Enums;

namespace DoctorAppointmentSystem.WebApi.Repository.Abstract;

public interface IDoctorRepository : IEntityRepository<Doctor, int, DoctorResponseDto>
{
    public IQueryable<DoctorResponseDto> GetByBranch(Branch branch);
    public IQueryable<DoctorResponseDto> GetByName(string name);
    public IQueryable<string> GetPatientsByDoctor(int id);
}
