using DoctorAppointmentSystem.WebApi.Dtos.Doctors.Request;
using DoctorAppointmentSystem.WebApi.Model.Enums;
using DoctorAppointmentSystem.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private IDoctorService _doctorService;
    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _doctorService.GetAll();
        return Ok(result.Data);
    }

    [HttpGet("getbyname")]
    public IActionResult GetByName([FromQuery] string name)
    {
        var result = _doctorService.GetByName(name);
        return Ok(result.Data);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        var result = _doctorService.GetById(id);
        return Ok(result.Data);
    }

    [HttpGet("getbybranch")]
    public IActionResult GetByBranch([FromQuery] string branchName)
    {
        var result = _doctorService.GetByBranch(branchName);
        return Ok(result.Data);
    }

    [HttpGet("getpatientsbydoctor")]
    public IActionResult GetPatientsByDoctor([FromQuery] int id)
    {
        var result = _doctorService.GetPatientsByDoctor(id);
        return Ok(result.Data);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] AddDoctorRequestDto requestDto)
    {
        var result = _doctorService.Add(requestDto);
        return Ok(result.Data);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateDoctorRequestDto requestDto)
    {
        var result = _doctorService.Update(requestDto);
        return Ok(result.Data);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromBody] int id)
    {
        var result = _doctorService.Delete(id);
        return Ok(result.Data);
    }
}
