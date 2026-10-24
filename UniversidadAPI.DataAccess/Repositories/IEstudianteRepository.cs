using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface IEstudianteRepository
{
    Task<List<Estudiante>> GetAllAsync();

    Task<Estudiante?> GetByIdAsync(int id);

    Task<Estudiante> CreateAsync(
        Estudiante estudiante
    );
    Task<Estudiante?> GetByUsuarioIdAsync(int usuarioId);
    Task UpdateAsync(
        Estudiante estudiante
    );

    Task DeleteAsync(
        Estudiante estudiante
    );
}