using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Repositories;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAllAsync();

    Task<Usuario?> GetByIdAsync(int id);

    Task<Usuario?> GetByUsernameAsync(string username);

    Task<Usuario> CreateAsync(Usuario usuario);

    Task UpdateAsync(Usuario usuario);

    Task DeleteAsync(Usuario usuario);


}