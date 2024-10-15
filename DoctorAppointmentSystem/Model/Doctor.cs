using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Request;
using DoctorAppointmentSystem.WebApi.Model.Enums;

namespace DoctorAppointmentSystem.WebApi.Model;

public class Doctor : EntityBase<int>
{
    public string Name { get; set; }
    public Branch Branch { get; set; }
    public List<string>? Patients { get; set; }

    public static explicit operator Doctor(AddDoctorRequestDto dto)
    {
        return new Doctor
        {
            Name = dto.Name,
            Branch = dto.Branch,
        };
    }
    public static explicit operator Doctor(UpdateDoctorRequestDto dto)
    {
        return new Doctor
        {
            Id = dto.Id,
            Name = dto.Name,
            Branch = dto.Branch,
        };
    }

}
