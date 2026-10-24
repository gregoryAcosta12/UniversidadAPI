using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Business.Services;

namespace UniversidadAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CarrerasController : ControllerBase
{
    private readonly ICarreraService _service;

    public CarrerasController(ICarreraService service)
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
        var carrera = await _service.GetByIdAsync(id);

        if (carrera == null)
            return NotFound();

        return Ok(carrera);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]  
    public async Task<IActionResult> Create(CarreraCreateDto dto)
    {
       
        var usuarioId = User.FindFirst("id")?.Value;
        var username = User.FindFirst("username")?.Value;


        var carrera = await _service.CreateAsync(dto);
        return Ok(carrera);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]  
    public async Task<IActionResult> Update(int id, CarreraUpdateDto dto)
    {
       
        var usuarioId = User.FindFirst("id")?.Value;

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