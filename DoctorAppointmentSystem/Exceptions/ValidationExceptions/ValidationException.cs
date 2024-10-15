namespace DoctorAppointmentSystem.WebApi.Exceptions.ValidationExceptions;

public class ValidationException : Exception
{
    public ValidationException()
    {
    }
    public ValidationException(string message) : base(message)
    {
    }
    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
