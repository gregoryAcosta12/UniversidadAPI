using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface IFacultadService
{
    Task<List<Facultad>> GetAllAsync();

    Task<Facultad?> GetByIdAsync(int id);

    Task<Facultad> CreateAsync(FacultadCreateDto dto);

    Task<bool> UpdateAsync(int id, FacultadUpdateDto dto);

    Task<bool> DeleteAsync(int id);
}