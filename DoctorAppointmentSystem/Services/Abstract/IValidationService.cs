using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Request;
using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Request;

namespace DoctorAppointmentSystem.WebApi.Services.Abstract
{
    public interface IValidationService
    {
         bool ValidateAddDoctorRequestDto(AddDoctorRequestDto dto);

         bool ValidateUpdateDoctorRequestDto(UpdateDoctorRequestDto dto);

         bool ValidateAddAppointmentRequestDto(AddAppointmentRequestDto dto);

         bool ValidateUpdateAppointmentRequestDto(UpdateAppointmentRequestDto dto);

         bool ValidateDateForm(DateTime appointmentDate);

         bool ValidateIdForm(int id);

         bool ValidateNameForm(string name);

         bool CheckNullOrEmpty(string answer);

         bool CheckText(string answer);
    }
}
