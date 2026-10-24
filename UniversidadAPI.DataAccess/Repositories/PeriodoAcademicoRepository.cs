using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class PeriodoAcademicoRepository
    : IPeriodoAcademicoRepository
{
    private readonly UniversidadDbContext _context;

    public PeriodoAcademicoRepository(
        UniversidadDbContext context
    )
    {
        _context = context;
    }

    public async Task<List<PeriodoAcademico>>
        GetAllAsync()
    {
        return await _context.Periodos_academicos
            .ToListAsync();
    }

    public async Task<PeriodoAcademico?>
        GetByIdAsync(int id)
    {
        return await _context.Periodos_academicos
            .FindAsync(id);
    }

    public async Task<PeriodoAcademico>
        CreateAsync(PeriodoAcademico periodo)
    {
        _context.Periodos_academicos.Add(periodo);

        await _context.SaveChangesAsync();

        return periodo;
    }

    public async Task UpdateAsync(
        PeriodoAcademico periodo
    )
    {
        _context.Periodos_academicos.Update(periodo);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(
        PeriodoAcademico periodo
    )
    {
        _context.Periodos_academicos.Remove(periodo);

        await _context.SaveChangesAsync();
    }
}