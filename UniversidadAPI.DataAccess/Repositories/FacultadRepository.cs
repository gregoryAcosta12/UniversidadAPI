using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class FacultadRepository : IFacultadRepository
{
    private readonly UniversidadDbContext _context;

    public FacultadRepository(UniversidadDbContext context)
    {
        _context = context;
    }

    public async Task<List<Facultad>> GetAllAsync()
    {
        return await _context.Facultades.ToListAsync();
    }

    public async Task<Facultad?> GetByIdAsync(int id)
    {
        return await _context.Facultades.FindAsync(id);
    }

    public async Task<Facultad> CreateAsync(Facultad facultad)
    {
        _context.Facultades.Add(facultad);

        await _context.SaveChangesAsync();

        return facultad;
    }

    public async Task UpdateAsync(Facultad facultad)
    {
        _context.Facultades.Update(facultad);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Facultad facultad)
    {
        _context.Facultades.Remove(facultad);

        await _context.SaveChangesAsync();
    }
}