using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Request;
using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Response;
using DoctorAppointmentSystem.WebApi.Exceptions.NotFoundExceptions;
using DoctorAppointmentSystem.WebApi.Exceptions.ValidationExceptions;
using DoctorAppointmentSystem.WebApi.Model;
using DoctorAppointmentSystem.WebApi.Model.Enums;
using DoctorAppointmentSystem.WebApi.Model.ReturnModels;
using DoctorAppointmentSystem.WebApi.Repository.Abstract;
using DoctorAppointmentSystem.WebApi.Services.Abstract;
using System.Net;
using System.Xml.Linq;


namespace DoctorAppointmentSystem.WebApi.Services.Concrete;

public class DoctorService : IDoctorService
{
    private IDoctorRepository _doctorRepository;
    private IValidationService _validationService;

    public DoctorService(IDoctorRepository doctorRepository, IValidationService validationService)
    {
        _doctorRepository = doctorRepository;
        _validationService = validationService;
    }
    public ReturnModel<IQueryable<DoctorResponseDto>> GetByBranch(string branchName)
    {
        try
        {   Branch branch = GetBranch(branchName);
            IQueryable<DoctorResponseDto> doctors = _doctorRepository.GetByBranch(branch);
            return ReturnModelOfSuccess(doctors, $"The doctors from the branch : {branch} has been retrieved");
        }
        catch (NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<DoctorResponseDto>> GetByName(string name)
    {
        try
        {
            IQueryable<DoctorResponseDto> doctors = _doctorRepository.GetByName(name);
            return ReturnModelOfSuccess(doctors, $"The doctors whose name includes '{name}' has been retrieved ");
        }
        catch (NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<string>> GetPatientsByDoctor(int id)
    {
        try
        {
            Doctor doctor = _doctorRepository.GetById(id);
            IQueryable<string> patients = _doctorRepository.GetPatientsByDoctor(id);
            return new ReturnModel<IQueryable<string>>
            {
                Data = patients,
                Message = $"The patient list of the Doctor {doctor.Name} has been retrieved: ",
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<IQueryable<string>>
            {
                Data = null,
                Message = ex.Message,
                Success = false,
                StatusCode = GetExceptionStatusCode(ex)
            };
        }
    }

    public ReturnModel<IQueryable<DoctorResponseDto>> GetAll()
    {
        try
        {
            IQueryable<DoctorResponseDto> doctors = _doctorRepository.GetAll();
            return ReturnModelOfSuccess(doctors, "The doctors have been retrieved");
               
        }
        catch (NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<DoctorResponseDto>> GetById(int id)
    {
        try
        {
            DoctorResponseDto doctor = _doctorRepository.GetById(id);
            IQueryable<DoctorResponseDto> doctorDto = ConvertIntoQueryable(doctor);

            return ReturnModelOfSuccess(doctorDto, $"The doctor with the id: {id} has been retrieved");
        }
        catch(NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }

    }
    public List<Branch> GetBranches()
    {
        List<Branch> branches = new List<Branch>() { Branch.Pediatry, Branch.Cardiology, Branch.Dermatology, Branch.Orthopedy, Branch.Gastroenterology, Branch.Neurology };
        return branches;
    }
    public Branch GetBranch(string branch)
    {

        Branch result;
        if (Enum.TryParse(branch, out result))
        {
            switch (result)
            {
                case Branch.Orthopedy:
                    return Branch.Orthopedy;
                case Branch.Pediatry:
                    return Branch.Pediatry;
                case Branch.Dermatology:
                    return Branch.Dermatology;
                case Branch.Cardiology:
                    return Branch.Cardiology;
                case Branch.Gastroenterology:
                    return Branch.Gastroenterology;
                case Branch.Neurology:
                    return Branch.Neurology;
            }
        }
        throw new ValidationException("There are no branches with that name");
    }

    public ReturnModel<IQueryable<DoctorResponseDto>> Add(AddDoctorRequestDto dto)
    {
        try
        {
            _validationService.ValidateAddDoctorRequestDto(dto);
            Doctor doctor = (Doctor)dto;
            DoctorResponseDto doctorDto = _doctorRepository.Add(doctor);
            IQueryable<DoctorResponseDto> queryableDoctorDto = ConvertIntoQueryable(doctor);
            return ReturnModelOfSuccess(queryableDoctorDto, "The doctor has been added to the database");
        }
        catch (ValidationException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<DoctorResponseDto>> Update(UpdateDoctorRequestDto entity)
    {
        try
        {
            _validationService.ValidateUpdateDoctorRequestDto(entity);
            Doctor doctor = (Doctor)entity;
            DoctorResponseDto doctorDto = _doctorRepository.Update(doctor);
            IQueryable<DoctorResponseDto> queryableDoctorDto = ConvertIntoQueryable(doctor);
            return ReturnModelOfSuccess(queryableDoctorDto, "The doctor has been Updated");
        }
        catch (Exception ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<DoctorResponseDto>> Delete(int id)
    {
        try
        {
            DoctorResponseDto doctor = _doctorRepository.Delete(id);
            IQueryable<DoctorResponseDto> doctorDto = ConvertIntoQueryable(doctor);
            return ReturnModelOfSuccess(doctorDto, "The doctor has been deleted");
        }
        catch (Exception ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<IQueryable<DoctorResponseDto>> ReturnModelOfSuccess(IQueryable<DoctorResponseDto> doctor, string message)
    {
        return new ReturnModel<IQueryable<DoctorResponseDto>> {
            Data = doctor,
            Message = message,
            Success = true,
            StatusCode = HttpStatusCode.OK
        };
    }

    public ReturnModel<IQueryable<DoctorResponseDto>> ReturnModelOfException(Exception ex)
    {
        return new ReturnModel<IQueryable<DoctorResponseDto>>
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

    


    public IQueryable<DoctorResponseDto> ConvertIntoQueryable(DoctorResponseDto doctor)
    {
        IQueryable<DoctorResponseDto> dto = new List<DoctorResponseDto> { doctor }.AsQueryable();

        return dto;
    }

    public bool CheckBranchValidity(Branch branch)
    {
        if (!GetBranches().Contains(branch))
        {
            throw new ValidationException("The Branch is invalid. Please input a valid branch", new InvalidBranchException());
        }
        return true;
    }
}
