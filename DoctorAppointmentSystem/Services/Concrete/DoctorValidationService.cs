using DoctorAppointmentSystem.WebApi.Repository.Abstract;
using DoctorAppointmentSystem.WebApi.Services.Abstract;

namespace DoctorAppointmentSystem.WebApi.Services.Concrete;

public class DoctorValidationService : IDoctorValidationService
{
    IDoctorRepository _doctorRepository;
    public DoctorValidationService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
    public IQueryable<string> GetPatients(int id)
    {
        IQueryable<string> patients = _doctorRepository.GetPatientsByDoctor(id);
        return patients;
    }
}
