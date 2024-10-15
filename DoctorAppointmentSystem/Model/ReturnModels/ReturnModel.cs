using System.Net;

namespace DoctorAppointmentSystem.WebApi.Model.ReturnModels;

public class ReturnModel<T>
{
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
    public T? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public override string ToString()
    {
        return $"Message : {Message}" +
            $"\nSuccess : {Success}" +
            $"\nStatus Code : {StatusCode}" +
            $"\nData : {Data}";
    }
}


