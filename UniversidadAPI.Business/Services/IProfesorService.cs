using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface IProfesorService
{
    Task<List<Profesor>> GetAllAsync();

    Task<Profesor?> GetByIdAsync(int id);

    Task<Profesor> CreateAsync(
        ProfesorCreateDto dto
    );

    Task<bool> UpdateAsync(
        int id,
        ProfesorUpdateDto dto
    );
    Task<List<Materia>> GetMateriasByProfesorIdAsync(int profesorId);
    Task<Profesor?> GetByUsuarioIdAsync(int usuarioId);
    Task<bool> DeleteAsync(int id);
}