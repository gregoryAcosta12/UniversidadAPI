using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Business.Services;

namespace UniversidadAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FacultadesController : ControllerBase
{
    private readonly IFacultadService _service;

    public FacultadesController(IFacultadService service)
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
        var facultad = await _service.GetByIdAsync(id);

        if (facultad == null)
            return NotFound();

        return Ok(facultad);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> Create(FacultadCreateDto dto)
    {
        var facultad = await _service.CreateAsync(dto);
        return Ok(facultad);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> Update(int id, FacultadUpdateDto dto)
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