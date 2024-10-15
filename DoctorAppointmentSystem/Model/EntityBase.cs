namespace DoctorAppointmentSystem.WebApi.Model;

public abstract class EntityBase<TId>
{
    public TId Id { get; set; }
}
