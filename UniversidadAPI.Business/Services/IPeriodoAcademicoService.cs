using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface IPeriodoAcademicoService
{
    Task<List<PeriodoAcademicoResponseDto>> GetAllAsync();

    Task<PeriodoAcademicoResponseDto?> GetByIdAsync(int id);

    Task<PeriodoAcademico> CreateAsync(PeriodoAcademicoCreateDto dto);

    Task<bool> UpdateAsync(int id, PeriodoAcademicoUpdateDto dto);

    Task<bool> DeleteAsync(int id);
}