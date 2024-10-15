using DoctorAppointmentSystem.WebApi.Model.Enums;

namespace DoctorAppointmentSystem.WebApi.Dtos.Doctors.Request;

public record AddDoctorRequestDto (
    string Name,
    Branch Branch
    )
{
}
