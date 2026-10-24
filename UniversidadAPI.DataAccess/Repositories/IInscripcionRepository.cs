using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface IInscripcionRepository
{
    Task<List<Inscripcion>> GetAllAsync();

    Task<Inscripcion?> GetByIdAsync(int id);

    Task<Inscripcion> CreateAsync(
        Inscripcion inscripcion
    );

    Task UpdateAsync(
        Inscripcion inscripcion
    );

    Task DeleteAsync(
        Inscripcion inscripcion
    );
    Task<List<Inscripcion>> GetByEstudianteIdAsync(int estudianteId);
}