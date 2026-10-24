using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface IMateriaService
{
    Task<List<Materia>> GetAllAsync();

    Task<Materia?> GetByIdAsync(int id);

    Task<Materia> CreateAsync(
        MateriaCreateDto dto);

    Task<bool> UpdateAsync(
        int id,
        MateriaUpdateDto dto);
    Task<List<Materia>> GetByEstudianteIdAsync(int estudianteId);
    Task<bool> DeleteAsync(int id);
}