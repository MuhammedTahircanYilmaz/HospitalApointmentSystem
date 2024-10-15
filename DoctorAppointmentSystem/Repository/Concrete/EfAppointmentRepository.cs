using DoctorAppointmentSystem.WebApi.Context;
using DoctorAppointmentSystem.WebApi.Model;
using DoctorAppointmentSystem.WebApi.Repository.Abstract;
using DoctorAppointmentSystem.WebApi.Exceptions.NotFoundExceptions;
using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Response;

namespace DoctorAppointmentSystem.WebApi.Repository.Concrete;

public class EfAppointmentRepository : IAppointmentRepository
{
    IConfiguration _configuration;
    MsSqlContext _context;

    public EfAppointmentRepository(MsSqlContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public IQueryable<AppointmentResponseDto> GetByDate(DateTime date)
    {
        IQueryable<AppointmentResponseDto> appointments = _context.Appointments.Where(x => x.AppointmentDate == date).Select(x=>(AppointmentResponseDto)x);
        if (appointments.Count() > 0)
        {
            throw new NotFoundException("There are not appointments dor the date searched", new AppointmentNotFoundException());
        }
        return appointments;
    }

    public IQueryable<AppointmentResponseDto> GetByDoctorId(int doctorId)
    {
        IQueryable<AppointmentResponseDto> appointments = _context.Appointments.Where(x => x.DoctorId == doctorId).Select(x => (AppointmentResponseDto)x);
        if (appointments.Count() > 0)
        {
            throw new NotFoundException("There are not appointments for the doctor searched", new AppointmentNotFoundException());
        }
        return appointments;
    }

    public IQueryable<AppointmentResponseDto> GetAll()
    {
        IQueryable<AppointmentResponseDto> appointments = _context.Appointments.Select(x=>(AppointmentResponseDto)x);
        if (appointments.Count() > 0)
        {
            throw new NotFoundException("There are no appointments found", new AppointmentNotFoundException());
        }
        return appointments;
    }

    public Appointment GetById(string id)
    {
        Appointment appointment = _context.Appointments.SingleOrDefault(x => x.Id == id);
        if (appointment == null)
        {
            throw new NotFoundException("There are no appointments found with given Id", new AppointmentNotFoundException());
        }
        return appointment;
    }

    public AppointmentResponseDto Add(Appointment entity)
    {
        _context.Appointments.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public AppointmentResponseDto Update(Appointment entity)
    {
        _context.Appointments.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public AppointmentResponseDto Delete(string id)
    {
        Appointment appointment = GetById(id);
        _context.Appointments.Remove(appointment);
        _context.SaveChanges();
        return appointment;
    }
}
