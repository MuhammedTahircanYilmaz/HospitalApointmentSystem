using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Request;
using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Response;
using DoctorAppointmentSystem.WebApi.Model;
using DoctorAppointmentSystem.WebApi.Model.ReturnModels;

namespace DoctorAppointmentSystem.WebApi.Services.Abstract;

public interface IAppointmentService : IEntityService <Appointment, string, AppointmentResponseDto, AddAppointmentRequestDto, UpdateAppointmentRequestDto >
{
    ReturnModel<IQueryable<AppointmentResponseDto>> GetByDate(DateTime date);
    ReturnModel<IQueryable<AppointmentResponseDto>> GetByDoctorId(int doctorId);
}
