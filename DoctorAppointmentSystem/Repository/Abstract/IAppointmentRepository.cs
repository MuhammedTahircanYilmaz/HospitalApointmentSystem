using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Response;
using DoctorAppointmentSystem.WebApi.Model;

namespace DoctorAppointmentSystem.WebApi.Repository.Abstract;

public interface IAppointmentRepository : IEntityRepository<Appointment, string, AppointmentResponseDto>
{
    IQueryable<AppointmentResponseDto> GetByDate(DateTime date);
    IQueryable<AppointmentResponseDto> GetByDoctorId(int doctorId);
}
