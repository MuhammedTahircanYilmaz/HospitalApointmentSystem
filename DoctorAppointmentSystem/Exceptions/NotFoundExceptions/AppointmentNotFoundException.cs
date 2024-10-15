namespace DoctorAppointmentSystem.WebApi.Exceptions.NotFoundExceptions;

public class AppointmentNotFoundException : Exception
{
    public AppointmentNotFoundException()
    {
    }
    public AppointmentNotFoundException(string message) : base(message)
    {
    }
    public AppointmentNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

}
