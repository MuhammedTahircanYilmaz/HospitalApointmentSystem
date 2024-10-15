using DoctorAppointmentSystem.WebApi.Model.Enums;

namespace DoctorAppointmentSystem.WebApi.Dtos.Doctors.Request;

public record UpdateDoctorRequestDto(
    int Id,
    string Name,
    Branch Branch
    )
{
   
}
