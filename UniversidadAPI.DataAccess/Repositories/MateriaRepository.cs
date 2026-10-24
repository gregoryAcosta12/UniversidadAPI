using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class MateriaRepository : IMateriaRepository
{
    private readonly UniversidadDbContext _context;

    public MateriaRepository(
        UniversidadDbContext context)
    {
        _context = context;
    }

    public async Task<List<Materia>> GetAllAsync()
    {
        return await _context.Materias
            .Include(m => m.Profesor)
            .ToListAsync();
    }

    public async Task<Materia?> GetByIdAsync(
        int id)
    {
        return await _context.Materias
            .Include(m => m.Profesor)
            .FirstOrDefaultAsync(
                m => m.Id == id);
    }

    public async Task<Materia> CreateAsync(
        Materia materia)
    {
        _context.Materias.Add(materia);

        await _context.SaveChangesAsync();

        return materia;
    }

    public async Task UpdateAsync(
        Materia materia)
    {
        _context.Materias.Update(materia);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Materia>> GetByEstudianteIdAsync(int estudianteId)
    {
        return await _context.Materias
            .Where(m => m.Inscripciones.Any(i => i.EstudianteId == estudianteId))
            .ToListAsync();
    }
    public async Task DeleteAsync(
        Materia materia)
    {
        _context.Materias.Remove(materia);

        await _context.SaveChangesAsync();
    }
}