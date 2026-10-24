using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface ICalificacionService
{
    Task<List<Calificacion>> GetAllAsync();

    Task<Calificacion?> GetByIdAsync(int id);

    Task<Calificacion> CreateAsync(
        CalificacionCreateDto dto
    );
    Task<List<Calificacion>> GetByEstudianteIdAsync(int estudianteId);

    Task<bool> UpdateAsync(
        int id,
        CalificacionUpdateDto dto
    );

    Task<bool> DeleteAsync(int id);
}