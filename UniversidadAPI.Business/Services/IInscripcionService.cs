using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface IInscripcionService
{
    Task<List<Inscripcion>> GetAllAsync();

    Task<Inscripcion?> GetByIdAsync(int id);

    Task<Inscripcion> CreateAsync(
        InscripcionCreateDto dto
    );

    Task<bool> UpdateAsync(
        int id,
        InscripcionUpdateDto dto
    );
    Task<List<Inscripcion>> GetByEstudianteIdAsync(int estudianteId);
    Task<bool> DeleteAsync(int id);
}
