using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class ProfesorRepository
    : IProfesorRepository
{
    private readonly UniversidadDbContext _context;

    public ProfesorRepository(
        UniversidadDbContext context)
    {
        _context = context;
    }

    public async Task<List<Profesor>> GetAllAsync()
    {
        return await _context.Profesores
            .Include(p => p.Materias)
            .ToListAsync();
    }

    public async Task<Profesor?> GetByIdAsync(
        int id)
    {
        return await _context.Profesores
            .Include(p => p.Materias)
            .FirstOrDefaultAsync(
                p => p.Id == id);
    }
    public async Task<List<Materia>> GetMateriasByProfesorIdAsync(int profesorId)
    {
        return await _context.Materias
            .Where(m => m.ProfesorId == profesorId)
            .ToListAsync();
    }

    public async Task<Profesor?> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _context.Profesores
            .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);
    }
    public async Task<Profesor> CreateAsync(
        Profesor profesor)
    {
        _context.Profesores.Add(profesor);

        await _context.SaveChangesAsync();

        return profesor;
    }

    public async Task UpdateAsync(
        Profesor profesor)
    {
        _context.Profesores.Update(profesor);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(
        Profesor profesor)
    {
        _context.Profesores.Remove(profesor);

        await _context.SaveChangesAsync();
    }
}