using DoctorAppointmentSystem.WebApi.Context;
using DoctorAppointmentSystem.WebApi.Model;
using DoctorAppointmentSystem.WebApi.Model.Enums;
using DoctorAppointmentSystem.WebApi.Repository.Abstract;
using DoctorAppointmentSystem.WebApi.Exceptions.NotFoundExceptions;
using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Response;

namespace DoctorAppointmentSystem.WebApi.Repository.Concrete;

public class EfDoctorRepository : IDoctorRepository
{
    MsSqlContext _context;
    public EfDoctorRepository(MsSqlContext context)
    {
        _context = context;
    }

    public IQueryable<DoctorResponseDto> GetByBranch(Branch branch)
    {
        IQueryable<DoctorResponseDto> doctors = _context.Doctors.Where(x => x.Branch == branch).Select(x=> (DoctorResponseDto)x);
        if (doctors.Count() > 0)
        {
            throw new NotFoundException("There are no Doctors found for the given Branch", new DoctorNotFoundException());
        }
        return doctors;
    }

    public IQueryable<DoctorResponseDto> GetByName(string name)
    {
        IQueryable<DoctorResponseDto> doctors = _context.Doctors.
            Where(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).Select(x=>(DoctorResponseDto)x);

        if (doctors.Count() > 0)
        {
            throw new NotFoundException("There are no Doctors found for the given Branch", new DoctorNotFoundException());
        }
        return doctors;
    }

    public IQueryable<DoctorResponseDto> GetAll()
    {
        return _context.Doctors.Select(x=>(DoctorResponseDto)x);
    }

    public Doctor GetById(int id)
    {
        Doctor doctor = _context.Doctors.SingleOrDefault(x => x.Id == id);
        if (doctor == null)
        {
            throw new NotFoundException($"There are no Doctors found with the provided id : '{id}'", new DoctorNotFoundException());
        }
        return doctor;
    }
    public IQueryable<string> GetPatientsByDoctor(int id)
    {
        Doctor doctor = GetById(id);
        IQueryable<string> patients = doctor.Patients.AsQueryable();
        if (patients.Count() > 0)
        {
            throw new NotFoundException("There are no patients fount for the Doctor");
        }
        return patients;
    }

    public DoctorResponseDto Add(Doctor entity)
    {
        _context.Doctors.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public DoctorResponseDto Update(Doctor entity)
    {
        _context.Doctors.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public DoctorResponseDto Delete(int id)
    {
        Doctor doctor = GetById(id);
        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
        return doctor;
    }
}
