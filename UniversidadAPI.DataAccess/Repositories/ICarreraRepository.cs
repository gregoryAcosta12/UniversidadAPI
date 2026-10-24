using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface ICarreraRepository
{
    Task<List<Carrera>> GetAllAsync();

    Task<Carrera?> GetByIdAsync(int id);

    Task<Carrera> CreateAsync(Carrera carrera);

    Task UpdateAsync(Carrera carrera);

    Task DeleteAsync(Carrera carrera);
}