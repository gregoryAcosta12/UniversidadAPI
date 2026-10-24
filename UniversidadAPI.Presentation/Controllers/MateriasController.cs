using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Business.Services;

namespace UniversidadAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MateriasController : ControllerBase
{
    private readonly IMateriaService _service;

    public MateriasController(IMateriaService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        var materia = await _service.GetByIdAsync(id);

        if (materia == null)
            return NotFound();

        return Ok(materia);
    }

    [HttpGet("mis-materias")]
    [Authorize(Roles = "ESTUDIANTE")]
    public async Task<IActionResult> GetMisMaterias()
    {
        var usuarioId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(usuarioId))
            return Unauthorized();

        var materias = await _service.GetByEstudianteIdAsync(int.Parse(usuarioId));
        return Ok(materias);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN,PROFESOR")]
    public async Task<IActionResult> Create(MateriaCreateDto dto)
    {
        var materia = await _service.CreateAsync(dto);
        return Ok(materia);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN,PROFESOR")]
    public async Task<IActionResult> Update(int id, MateriaUpdateDto dto)
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