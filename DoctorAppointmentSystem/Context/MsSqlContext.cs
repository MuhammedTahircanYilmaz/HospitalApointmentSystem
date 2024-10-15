using DoctorAppointmentSystem.WebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentSystem.WebApi.Context;

public class MsSqlContext : DbContext
{
    public MsSqlContext(DbContextOptions opt) : base(opt)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = localhost, 1433; Database = Appointment_db; User = sa; Password = admin123456789; TrustServerCertificate =true",
        
        // Enable transient error resiliency with default retry settings
        sqlServerOptionsAction: sqlOptions => {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10, // Number of retry attempts
                maxRetryDelay: TimeSpan.FromSeconds(30), // Max delay between retries
                errorNumbersToAdd: null // Specify additional SQL error numbers (optional)
            );
        });

    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}
