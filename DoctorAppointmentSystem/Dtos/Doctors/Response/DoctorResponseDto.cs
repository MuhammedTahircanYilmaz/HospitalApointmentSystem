using DoctorAppointmentSystem.WebApi.Model.Enums;
using DoctorAppointmentSystem.WebApi.Model;

namespace DoctorAppointmentSystem.WebApi.Dtos.Doctors.Response;

public record DoctorResponseDto(
    string Name,
    Branch Branch
    )
{

    public static implicit operator DoctorResponseDto(Doctor doctor)
    {
        return new DoctorResponseDto(
            Name: doctor.Name,
            Branch: doctor.Branch);
    }
}
