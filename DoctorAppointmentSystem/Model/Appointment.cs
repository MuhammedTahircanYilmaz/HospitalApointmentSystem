using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Request;

namespace DoctorAppointmentSystem.WebApi.Model;

public class Appointment : EntityBase<string>
{
    public string PatientName { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    public List<Doctor> Doctors { get; set; }

    public Appointment()
    {
        Id = Guid.NewGuid().ToString();
    }

    public static explicit operator Appointment(AddAppointmentRequestDto dto)
    {
        return new Appointment
        {
            PatientName = dto.PatientName,
            AppointmentDate = dto.AppointmentDate,
            DoctorId = dto.DoctorId
        };
    }
    public static explicit operator Appointment(UpdateAppointmentRequestDto dto)
    {
        return new Appointment
        {
            Id = dto.Id,
            PatientName = dto.PatientName,
            AppointmentDate = dto.AppointmentDate,
            DoctorId = dto.DoctorId
        };
    }
}
