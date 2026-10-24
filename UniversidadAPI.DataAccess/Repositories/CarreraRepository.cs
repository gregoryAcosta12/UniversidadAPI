using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class CarreraRepository : ICarreraRepository
{
    private readonly UniversidadDbContext _context;

    public CarreraRepository(
        UniversidadDbContext context
    )
    {
        _context = context;
    }

    public async Task<List<Carrera>> GetAllAsync()
    {
        return await _context.Carreras
            .Include(c => c.Facultad)
            .ToListAsync();
    }

    public async Task<Carrera?> GetByIdAsync(int id)
    {
        return await _context.Carreras
            .Include(c => c.Facultad)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Carrera> CreateAsync(
        Carrera carrera
    )
    {
        _context.Carreras.Add(carrera);

        await _context.SaveChangesAsync();

        return carrera;
    }

    public async Task UpdateAsync(
        Carrera carrera
    )
    {
        _context.Carreras.Update(carrera);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(
        Carrera carrera
    )
    {
        _context.Carreras.Remove(carrera);

        await _context.SaveChangesAsync();
    }
}