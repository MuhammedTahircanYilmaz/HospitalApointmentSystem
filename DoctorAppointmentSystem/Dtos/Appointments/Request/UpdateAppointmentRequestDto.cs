namespace DoctorAppointmentSystem.WebApi.Dtos.Appointments.Request;

public record UpdateAppointmentRequestDto(
    string Id,
    string PatientName,
    DateTime AppointmentDate,
    int DoctorId
    )
{
}
