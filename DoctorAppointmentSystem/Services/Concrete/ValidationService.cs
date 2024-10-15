using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Request;
using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Request;
using DoctorAppointmentSystem.WebApi.Exceptions.ValidationExceptions;
using DoctorAppointmentSystem.WebApi.Model.Enums;
using DoctorAppointmentSystem.WebApi.Services.Abstract;
using Microsoft.SqlServer.Server;
using System.IO;

namespace DoctorAppointmentSystem.WebApi.Services.Concrete;

public class ValidationService : IValidationService
{
    IDoctorValidationService _doctorValidationService;
    public ValidationService(IDoctorValidationService doctorValidationService)
    {
        _doctorValidationService = doctorValidationService;
    }
    public bool ValidateAddDoctorRequestDto(AddDoctorRequestDto dto)
    {
        if (!ValidateNameForm(dto.Name))
        {
            throw new ValidationException("The name field is invalid. Please input a valid name", new InvalidNameException());
        }
        return true;
    }

    public bool ValidateUpdateDoctorRequestDto(UpdateDoctorRequestDto dto)
    {

        if (!ValidateIdForm(dto.Id))
        {
            throw new ValidationException("The Id form is invalid. Please input a valid Id", new InvalidIdException());
        }
        if (!ValidateNameForm(dto.Name))
        {
            throw new ValidationException("The name field is invalid. Please input a valid name", new InvalidNameException());
        }
        return true;
    }

    public bool ValidateAddAppointmentRequestDto(AddAppointmentRequestDto dto)
    {
        if (!ValidateNameForm(dto.PatientName))
        {
            throw new ValidationException("The name field is invalid. Please input a valid name", new InvalidNameException());
        }
        if (!ValidateIdForm(dto.DoctorId))
        {
            throw new ValidationException("The Id form is invalid. Please input a valid Id", new InvalidIdException());
        }
        if (!ValidateDateForm(dto.AppointmentDate))
        {
            throw new ValidationException("The Date is invalid. Please input a valid date", new InvalidDateException());
        }
        if (!ValidatePatientNumber(dto.DoctorId))
        {
            throw new ValidationException("There are already ten(10) patients. Please choose another doctor");
        }
        return true;
    }


    public bool ValidateUpdateAppointmentRequestDto(UpdateAppointmentRequestDto dto)
    {
        if (!ValidateNameForm(dto.PatientName))
        {
            throw new ValidationException("The name field is invalid. Please input a valid name", new InvalidNameException());
        }
        if (!ValidateIdForm(dto.DoctorId))
        {
            throw new ValidationException("The Id form is invalid. Please input a valid Id", new InvalidIdException());
        }
        if (!ValidateDateForm(dto.AppointmentDate))
        {
            throw new ValidationException("The Date is invalid. Please input a valid date", new InvalidDateException());
        }
        if (!ValidatePatientNumber(dto.DoctorId))
        {
            throw new ValidationException("There are already ten(10) patients. Please choose another doctor");
        }
        return true;
    }

    public bool ValidateDateForm(DateTime appointmentDate)
    {
        DateTime Today = DateTime.Now;
        if(appointmentDate<Today)
        {
            Console.WriteLine("The appointment date cannot be prior to today");
            return false;
        }
        if (appointmentDate < Today.AddDays(3))
        {
            Console.WriteLine("The date has to be at least three days from now");
        }
        return true;
    }

    public bool ValidateIdForm(int id)
    {
        if (CheckNullOrEmpty(Convert.ToString(id)))
        {
            throw new ValidationException("This field cannot be null or empty", new NullFieldException());
        }
        if (id <= 0)
        {
            throw new ValidationException("The Id cannot be lower than or equal to zero");
        }
        return true;
    }

    public bool ValidateNameForm(string name)
    {
        if (CheckNullOrEmpty(name))
        {
            throw new ValidationException("This field cannot be null or empty", new NullFieldException());
        }
        if (!CheckText(name))
        {
            throw new ValidationException("This field has to consist of only letters", new InvalidTypeException());
        }
        return true;
    }

    private bool ValidatePatientNumber(int doctorId)
    {
        IQueryable<string> patients = _doctorValidationService.GetPatients(doctorId);
        if (patients.Count() <= 10)
        {
            return true;
        }
        return false;
    }

    public bool CheckNullOrEmpty(string answer)
    {
        if (string.IsNullOrEmpty(answer))
        {
            return true;
        }
        if (string.IsNullOrWhiteSpace(answer))
        {
            return true;
        }
        return false;
    }
    public bool CheckText(string answer)
    {
        return answer.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }

}


/*
 * doctor 
 *  Add
 *      name,branch validation
 *  update
 *      + id validation
 *      
 *  appointment
 *      add
 *      name, date , doctorId validation
 *      
 *  update
 *      id validation
 *      
 *      
 *  
 *  
 * 
 */