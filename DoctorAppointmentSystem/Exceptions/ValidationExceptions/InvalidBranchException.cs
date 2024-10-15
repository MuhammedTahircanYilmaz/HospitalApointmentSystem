namespace DoctorAppointmentSystem.WebApi.Exceptions.ValidationExceptions
{
    public class InvalidBranchException : Exception
    {
        public InvalidBranchException()
        {
        }

        public InvalidBranchException(string message) : base(message)
        {
        }

        public InvalidBranchException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
