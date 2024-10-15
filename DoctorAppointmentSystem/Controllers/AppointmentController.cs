using DoctorAppointmentSystem.WebApi.Dtos.Appointments.Request;
using DoctorAppointmentSystem.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    
    private IAppointmentService _appointmentService;
    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _appointmentService.GetAll();
        return Ok(result.Data);
    }

    [HttpGet("getbydate")]
    public IActionResult GetByDate([FromQuery] DateTime date)
    {
        var result = _appointmentService.GetByDate(date);
        return Ok(result.Data);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] string id)
    {
        var result = _appointmentService.GetById(id);
        return Ok(result.Data);
    }

    [HttpGet("getbydoctorid")]
    public IActionResult GetByDoctorId([FromQuery] int doctorId)
    {
        var result = _appointmentService.GetByDoctorId(doctorId);
        return Ok(result.Data);
    }

    [HttpPost("add")]
    public IActionResult Add(AddAppointmentRequestDto requestDto)
    {
        var result = _appointmentService.Add(requestDto);
        return Ok(result.Data);
    }

    [HttpPut("update")]
    public IActionResult Update(UpdateAppointmentRequestDto requestDto)
    {
        var result = _appointmentService.Update(requestDto);
        return Ok(result.Data);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(string id)
    {
        var result = _appointmentService.Delete(id);
        return Ok(result.Data);
    }
    
}
