using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface ICalificacionRepository
{
    Task<List<Calificacion>> GetAllAsync();

    Task<Calificacion?> GetByIdAsync(int id);

    Task<Calificacion> CreateAsync(
        Calificacion calificacion
    );
    Task<List<Calificacion>> GetByEstudianteIdAsync(int estudianteId);
    Task UpdateAsync(
        Calificacion calificacion
    );

    Task DeleteAsync(
        Calificacion calificacion
    );
}