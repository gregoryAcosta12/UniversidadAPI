using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Business.Services;

namespace UniversidadAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InscripcionesController : ControllerBase
{
    private readonly IInscripcionService _service;

    public InscripcionesController(IInscripcionService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN,PROFESOR")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("mis-inscripciones")]
    [Authorize(Roles = "ESTUDIANTE")]
    public async Task<IActionResult> GetMisInscripciones()
    {
        var usuarioId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(usuarioId))
            return Unauthorized();

        var inscripciones = await _service.GetByEstudianteIdAsync(int.Parse(usuarioId));
        return Ok(inscripciones);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "ADMIN,PROFESOR")]
    public async Task<IActionResult> GetById(int id)
    {
        var inscripcion = await _service.GetByIdAsync(id);

        if (inscripcion == null)
            return NotFound();

        return Ok(inscripcion);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN,PROFESOR")]
    public async Task<IActionResult> Create(InscripcionCreateDto dto)
    {
        var inscripcion = await _service.CreateAsync(dto);
        return Ok(inscripcion);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN,PROFESOR")]
    public async Task<IActionResult> Update(int id, InscripcionUpdateDto dto)
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