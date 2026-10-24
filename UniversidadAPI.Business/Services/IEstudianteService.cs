using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface IEstudianteService
{
    Task<List<Estudiante>> GetAllAsync();

    Task<Estudiante?> GetByIdAsync(int id);

    Task<Estudiante> CreateAsync(
        EstudianteCreateDto dto
    );
    Task<Estudiante?> GetByUsuarioIdAsync(int usuarioId);
    Task<bool> UpdateAsync(
        int id,
        EstudianteUpdateDto dto
    );

    Task<bool> DeleteAsync(int id);
}