namespace DoctorAppointmentSystem.WebApi.Dtos.Appointments.Request;

public record AddAppointmentRequestDto(
    string PatientName,
    DateTime AppointmentDate,
    int DoctorId
    )
{
}
