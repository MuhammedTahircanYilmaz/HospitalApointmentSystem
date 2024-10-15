using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Request;
using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Response;
using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Response;
using DoctorAppointmentSystem.WebApi.Exceptions.NotFoundExceptions;
using DoctorAppointmentSystem.WebApi.Exceptions.ValidationExceptions;
using DoctorAppointmentSystem.WebApi.Model;
using DoctorAppointmentSystem.WebApi.Model.ReturnModels;
using DoctorAppointmentSystem.WebApi.Repository.Abstract;
using DoctorAppointmentSystem.WebApi.Repository.Concrete;
using DoctorAppointmentSystem.WebApi.Services.Abstract;
using System.Net;
using System.Numerics;

namespace DoctorAppointmentSystem.WebApi.Services.Concrete;

public class AppointmentService : IAppointmentService
{
    private IAppointmentRepository _appointmentRepository;
    private IDoctorService _doctorService;
    private IValidationService _validationService;
    public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorService doctorService, IValidationService validationService)
    {
        _appointmentRepository = appointmentRepository;
        _doctorService = doctorService;
        _validationService = validationService;
    }
    public ReturnModel<IQueryable<AppointmentResponseDto>> GetByDate(DateTime date)
    {
        try
        {
            IQueryable<AppointmentResponseDto> appointments = _appointmentRepository.GetByDate(date);
            return ReturnModelOfSuccess(appointments, $"The appointments from the date  {date} has been retrieved");
        }
        catch (NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<AppointmentResponseDto>> GetByDoctorId(int doctorId)
    {
        try
        {
            IQueryable<AppointmentResponseDto> appointments = _appointmentRepository.GetByDoctorId(doctorId);
            return ReturnModelOfSuccess(appointments, $"The appointments for the doctor with the id {doctorId} has been retrieved");
        }
        catch (NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<AppointmentResponseDto>> GetAll()
    {
        try
        {
            IQueryable<AppointmentResponseDto> appointments = _appointmentRepository.GetAll();
            return ReturnModelOfSuccess(appointments, "The appointments have been retrieved");
        }
        catch(NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<AppointmentResponseDto>> GetById(string id)
    {
        try
        {
            AppointmentResponseDto appointment = _appointmentRepository.GetById(id);
            IQueryable<AppointmentResponseDto> appointmentDto = ConvertIntoQueryable(appointment);
            return ReturnModelOfSuccess(appointmentDto, $"The appointment with the Id {id} has been retrieved");
        }
        catch (NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<AppointmentResponseDto>> Add(AddAppointmentRequestDto dto)
    {
        try
        {
            _validationService.ValidateAddAppointmentRequestDto(dto);      
            Appointment appointment = (Appointment)dto;
            AppointmentResponseDto appointmentDto = _appointmentRepository.Add(appointment);
            IQueryable<AppointmentResponseDto> queryableAppointmentDto = ConvertIntoQueryable(appointment);
            return ReturnModelOfSuccess(queryableAppointmentDto, "The appointment has been added to the database");
        }
        catch (Exception ex)
        {
            return ReturnModelOfException(ex);
        }
    }
    
    public ReturnModel<IQueryable<AppointmentResponseDto>> Update(UpdateAppointmentRequestDto entity)
    {
        try
        {
            _validationService.ValidateUpdateAppointmentRequestDto(entity);
            Appointment appointment = (Appointment)entity;
            AppointmentResponseDto appointmentDto = _appointmentRepository.Update(appointment);
            IQueryable<AppointmentResponseDto> queryableAppointmentDto = ConvertIntoQueryable(appointment);
            return ReturnModelOfSuccess(queryableAppointmentDto, "The appointment has been updated");

        }
        catch (Exception ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<AppointmentResponseDto>> Delete(string id)
    {
        try
        {
            AppointmentResponseDto appointmentDto = _appointmentRepository.Delete(id);
            IQueryable<AppointmentResponseDto> queryableAppointmentDto = ConvertIntoQueryable(appointmentDto);
            return ReturnModelOfSuccess(queryableAppointmentDto, "The appointment has been updated");
        }
        catch (Exception ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<AppointmentResponseDto>> ReturnModelOfSuccess(IQueryable<AppointmentResponseDto> entity, string message)
    {
        return new ReturnModel<IQueryable<AppointmentResponseDto>>
        {
            Data = entity,
            Message = message,
            Success = true,
            StatusCode = HttpStatusCode.OK
        };
    }

    public ReturnModel<IQueryable<AppointmentResponseDto>> ReturnModelOfException(Exception ex)
    {
        return new ReturnModel<IQueryable<AppointmentResponseDto>>
        {
            Data = null,
            Message = ex.Message,
            Success = false,
            StatusCode = GetExceptionStatusCode(ex)
        };
    }

    public HttpStatusCode GetExceptionStatusCode(Exception ex)
    {

        return ex switch
        {
            NotFoundException => HttpStatusCode.NotFound,
            ValidationException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };
    }

    public IQueryable<AppointmentResponseDto> ConvertIntoQueryable(AppointmentResponseDto entity)
    {
        IQueryable<AppointmentResponseDto> dto = new List<AppointmentResponseDto> { entity }.AsQueryable();
        return dto;
    }
}
