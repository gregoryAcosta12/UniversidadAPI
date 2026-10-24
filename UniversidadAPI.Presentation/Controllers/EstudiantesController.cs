using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Business.Services;

namespace UniversidadAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]  
public class EstudiantesController : ControllerBase
{
    private readonly IEstudianteService _service;

    public EstudiantesController(IEstudianteService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN,PROFESOR")]  
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("mi-perfil")]  
    [Authorize(Roles = "ESTUDIANTE")]
    public async Task<IActionResult> GetMiPerfil()
    {
        var usuarioId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(usuarioId))
            return Unauthorized();

        var estudiante = await _service.GetByUsuarioIdAsync(int.Parse(usuarioId));

        if (estudiante == null)
            return NotFound();

        return Ok(estudiante);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "ADMIN,PROFESOR")]  
    public async Task<IActionResult> GetById(int id)
    {
        var estudiante = await _service.GetByIdAsync(id);

        if (estudiante == null)
            return NotFound();

        return Ok(estudiante);
    }

    [HttpPost]
    [AllowAnonymous] 
    public async Task<IActionResult> Create(EstudianteCreateDto dto)
    {
        var estudiante = await _service.CreateAsync(dto);
        return Ok(estudiante);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN,PROFESOR")]  
    public async Task<IActionResult> Update(int id, EstudianteUpdateDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPut("mi-perfil")]
    [Authorize(Roles = "ESTUDIANTE")] 
    public async Task<IActionResult> UpdateMiPerfil(EstudianteUpdateDto dto)
    {
        var usuarioId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(usuarioId))
            return Unauthorized();

        var estudiante = await _service.GetByUsuarioIdAsync(int.Parse(usuarioId));

        if (estudiante == null)
            return NotFound();

        var result = await _service.UpdateAsync(estudiante.Id, dto);

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