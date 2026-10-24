using Microsoft.EntityFrameworkCore;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UniversidadDbContext _context;

    public UsuarioRepository(
        UniversidadDbContext context
    )
    {
        _context = context;
    }

    public async Task<List<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario?> GetByUsernameAsync(
        string username
    )
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(
                x => x.Username == username
            );
    }

    public async Task<Usuario> CreateAsync(
        Usuario usuario
    )
    {
        _context.Usuarios.Add(usuario);

        await _context.SaveChangesAsync();

        return usuario;
    }

    public async Task UpdateAsync(
        Usuario usuario
    )
    {
        _context.Usuarios.Update(usuario);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(
        Usuario usuario
    )
    {
        _context.Usuarios.Remove(usuario);

        await _context.SaveChangesAsync();
    }
}