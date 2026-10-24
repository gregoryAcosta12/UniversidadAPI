using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class CalificacionRepository : ICalificacionRepository
{
    private readonly UniversidadDbContext _context;

    public CalificacionRepository(UniversidadDbContext context)
    {
        _context = context;
    }

    public async Task<List<Calificacion>> GetAllAsync()
    {
        return await _context.Calificaciones
            .Include(c => c.Estudiante)  
            .Include(c => c.Materia)     
            .ToListAsync();
    }

    public async Task<Calificacion?> GetByIdAsync(int id)
    {
        return await _context.Calificaciones
            .Include(c => c.Estudiante)  
            .Include(c => c.Materia)    
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Calificacion> CreateAsync(Calificacion calificacion)
    {
        _context.Calificaciones.Add(calificacion);
        await _context.SaveChangesAsync();
        return calificacion;
    }
    public async Task<List<Calificacion>> GetByEstudianteIdAsync(int estudianteId)
    {
        return await _context.Calificaciones
            .Include(c => c.Estudiante)
            .Include(c => c.Materia)
            .Where(c => c.Estudianteid == estudianteId)  
            .ToListAsync();
    }
    public async Task UpdateAsync(Calificacion calificacion)
    {
        _context.Calificaciones.Update(calificacion);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Calificacion calificacion)
    {
        _context.Calificaciones.Remove(calificacion);
        await _context.SaveChangesAsync();
    }
}