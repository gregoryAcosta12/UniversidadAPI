using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface IFacultadRepository
{
    Task<List<Facultad>> GetAllAsync();

    Task<Facultad?> GetByIdAsync(int id);

    Task<Facultad> CreateAsync(Facultad facultad);

    Task UpdateAsync(Facultad facultad);

    Task DeleteAsync(Facultad facultad);
}