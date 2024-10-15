
namespace DoctorAppointmentSystem.WebApi.Services.Abstract
{
    public interface IDoctorValidationService
    {
        IQueryable<string> GetPatients(int id);
    }
}
