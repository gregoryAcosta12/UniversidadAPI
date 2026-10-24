using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public interface IUsuarioService
{
    Task<List<Usuario>> GetAllAsync();

    Task<Usuario?> GetByIdAsync(int id);

    Task<Usuario> CreateAsync(
        UsuarioCreateDto dto
    );

    Task<bool> UpdateAsync(
        int id,
        UsuarioUpdateDto dto
    );

    Task<bool> DeleteAsync(int id);
}