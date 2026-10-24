using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class InscripcionRepository
    : IInscripcionRepository
{
    private readonly UniversidadDbContext _context;

    public InscripcionRepository(
        UniversidadDbContext context
    )
    {
        _context = context;
    }

    public async Task<List<Inscripcion>>
        GetAllAsync()
    {
        return await _context.Inscripciones
            .ToListAsync();
    }

    public async Task<Inscripcion?>
        GetByIdAsync(int id)
    {
        return await _context.Inscripciones
            .FindAsync(id);
    }

    public async Task<Inscripcion>
        CreateAsync(Inscripcion inscripcion)
    {
        _context.Inscripciones.Add(inscripcion);

        await _context.SaveChangesAsync();

        return inscripcion;
    }

    public async Task UpdateAsync(
        Inscripcion inscripcion
    )
    {
        _context.Inscripciones.Update(inscripcion);

        await _context.SaveChangesAsync();
    }
    public async Task<List<Inscripcion>> GetByEstudianteIdAsync(int estudianteId)
    {
        return await _context.Inscripciones
            .Include(i => i.Estudiante)
            .Include(i => i.Materia)
            .Include(i => i.PeriodoAcademico)
            .Where(i => i.EstudianteId == estudianteId)
            .ToListAsync();
    }
    public async Task DeleteAsync(
        Inscripcion inscripcion
    )
    {
        _context.Inscripciones.Remove(inscripcion);

        await _context.SaveChangesAsync();
    }
}