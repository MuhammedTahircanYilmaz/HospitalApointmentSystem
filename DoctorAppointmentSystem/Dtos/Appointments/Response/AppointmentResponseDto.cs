using DoctorAppointmentSystem.WebApi.Model;

namespace DoctorAppointmentSystem.WebApi.Dtos.Appointments.Response;

public record AppointmentResponseDto(
    string PatientName,
    DateTime AppointmentDate,
    int DoctorId
    )
{
    public static implicit operator AppointmentResponseDto(Appointment appointment)
    {
        return new AppointmentResponseDto(
            PatientName: appointment.PatientName,
            AppointmentDate: appointment.AppointmentDate,
            DoctorId: appointment.DoctorId
            );
    }
}
