using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface IPeriodoAcademicoRepository
{
    Task<List<PeriodoAcademico>> GetAllAsync();

    Task<PeriodoAcademico?> GetByIdAsync(int id);

    Task<PeriodoAcademico> CreateAsync(
        PeriodoAcademico periodo
    );

    Task UpdateAsync(
        PeriodoAcademico periodo
    );

    Task DeleteAsync(
        PeriodoAcademico periodo
    );
}