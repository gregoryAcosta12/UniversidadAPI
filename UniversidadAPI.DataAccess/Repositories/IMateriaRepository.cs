using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface IMateriaRepository
{
    Task<List<Materia>> GetAllAsync();

    Task<Materia?> GetByIdAsync(int id);

    Task<Materia> CreateAsync(Materia materia);

    Task UpdateAsync(Materia materia);

    Task<List<Materia>> GetByEstudianteIdAsync(int estudianteId);
    Task DeleteAsync(Materia materia);
}