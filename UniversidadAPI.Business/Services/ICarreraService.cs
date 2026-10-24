using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface ICarreraService
{
    Task<List<Carrera>> GetAllAsync();

    Task<Carrera?> GetByIdAsync(int id);

    Task<Carrera> CreateAsync(
        CarreraCreateDto dto
    );

    Task<bool> UpdateAsync(
        int id,
        CarreraUpdateDto dto
    );

    Task<bool> DeleteAsync(int id);
}