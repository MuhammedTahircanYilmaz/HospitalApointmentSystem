namespace DoctorAppointmentSystem.WebApi.Exceptions.ValidationExceptions
{
    public class NullFieldException : Exception
    {
        public NullFieldException()
        {
        }

        public NullFieldException(string message) : base(message)
        {
        }

        public NullFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
