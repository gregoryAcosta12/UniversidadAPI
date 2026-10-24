using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class EstudianteRepository
    : IEstudianteRepository
{
    private readonly UniversidadDbContext _context;

    public EstudianteRepository(
        UniversidadDbContext context)
    {
        _context = context;
    }

    public async Task<List<Estudiante>> GetAllAsync()
    {
        return await _context.Estudiantes
            .Include(e => e.Carrera)
            .ToListAsync();
    }

    public async Task<Estudiante?> GetByIdAsync(
        int id)
    {
        return await _context.Estudiantes
            .Include(e => e.Carrera)
            .FirstOrDefaultAsync(
                e => e.Id == id);
    }

    public async Task<Estudiante> CreateAsync(
        Estudiante estudiante)
    {
        _context.Estudiantes.Add(estudiante);

        await _context.SaveChangesAsync();

        return estudiante;
    }

    public async Task UpdateAsync(
        Estudiante estudiante)
    {
        _context.Estudiantes.Update(estudiante);

        await _context.SaveChangesAsync();
    }
    public async Task<Estudiante?> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _context.Estudiantes
            .Include(e => e.Carrera)
            .FirstOrDefaultAsync(e => e.UsuarioId == usuarioId);
    }
    public async Task DeleteAsync(
        Estudiante estudiante)
    {
        _context.Estudiantes.Remove(estudiante);

        await _context.SaveChangesAsync();
    }
}