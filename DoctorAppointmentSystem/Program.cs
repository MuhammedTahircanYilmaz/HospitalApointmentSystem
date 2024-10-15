using DoctorAppointmentSystem.WebApi.Context;
using DoctorAppointmentSystem.WebApi.Repository.Abstract;
using DoctorAppointmentSystem.WebApi.Repository.Concrete;
using DoctorAppointmentSystem.WebApi.Services.Abstract;
using DoctorAppointmentSystem.WebApi.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDoctorRepository, EfDoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<IDoctorValidationService, DoctorValidationService>();
builder.Services.AddDbContext<MsSqlContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
