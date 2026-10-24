using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Business.Services;

namespace UniversidadAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CalificacionesController : ControllerBase
{
    private readonly ICalificacionService _service;

    public CalificacionesController(ICalificacionService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN,PROFESOR")]  
    public async Task<IActionResult> GetAll()
    {
        var calificaciones = await _service.GetAllAsync();
        return Ok(calificaciones);
    }

    [HttpGet("mis-calificaciones")]  
    [Authorize(Roles = "ESTUDIANTE")]
    public async Task<IActionResult> GetMisCalificaciones()
    {
        var usuarioId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(usuarioId))
            return Unauthorized();

        var calificaciones = await _service.GetByEstudianteIdAsync(int.Parse(usuarioId));
        return Ok(calificaciones);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "ADMIN,PROFESOR")]
    public async Task<IActionResult> GetById(int id)
    {
        var calificacion = await _service.GetByIdAsync(id);

        if (calificacion == null)
            return NotFound();

        return Ok(calificacion);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN,PROFESOR")]  
    public async Task<IActionResult> Create(CalificacionCreateDto dto)
    {
        var calificacion = await _service.CreateAsync(dto);
        return Ok(calificacion);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN,PROFESOR")]  
    public async Task<IActionResult> Update(int id, CalificacionUpdateDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]  
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}