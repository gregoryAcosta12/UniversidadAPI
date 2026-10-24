using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface IProfesorRepository
{
    Task<List<Profesor>> GetAllAsync();

    Task<Profesor?> GetByIdAsync(int id);

    Task<Profesor> CreateAsync(Profesor profesor);

    Task<List<Materia>> GetMateriasByProfesorIdAsync(int profesorId);
    Task<Profesor?> GetByUsuarioIdAsync(int usuarioId);
    Task UpdateAsync(Profesor profesor);

    Task DeleteAsync(Profesor profesor);
}