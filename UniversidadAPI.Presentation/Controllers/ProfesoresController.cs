using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Business.Services;

namespace UniversidadAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfesoresController : ControllerBase
{
    private readonly IProfesorService _service;

    public ProfesoresController(IProfesorService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("mis-materias")]
    [Authorize(Roles = "PROFESOR")]
    public async Task<IActionResult> GetMisMaterias()
    {
        var usuarioId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(usuarioId))
            return Unauthorized();

        var materias = await _service.GetMateriasByProfesorIdAsync(int.Parse(usuarioId));
        return Ok(materias);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetById(int id)
    {
        var profesor = await _service.GetByIdAsync(id);

        if (profesor == null)
            return NotFound();

        return Ok(profesor);
    }

    [HttpGet("mi-perfil")]
    [Authorize(Roles = "PROFESOR")]
    public async Task<IActionResult> GetMiPerfil()
    {
        var usuarioId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(usuarioId))
            return Unauthorized();

        var profesor = await _service.GetByUsuarioIdAsync(int.Parse(usuarioId));

        if (profesor == null)
            return NotFound();

        return Ok(profesor);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(ProfesorCreateDto dto)
    {
        var profesor = await _service.CreateAsync(dto);
        return Ok(profesor);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> Update(int id, ProfesorUpdateDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPut("mi-perfil")]
    [Authorize(Roles = "PROFESOR")]
    public async Task<IActionResult> UpdateMiPerfil(ProfesorUpdateDto dto)
    {
        var usuarioId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(usuarioId))
            return Unauthorized();

        var profesor = await _service.GetByUsuarioIdAsync(int.Parse(usuarioId));

        if (profesor == null)
            return NotFound();

        var result = await _service.UpdateAsync(profesor.Id, dto);

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