using UniversidadAPI.Business.DTOs;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(
        IUsuarioRepository repository
    )
    {
        _repository = repository;
    }

    public async Task<List<Usuario>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Usuario> CreateAsync(
        UsuarioCreateDto dto
    )
    {
        var existe =
            await _repository.GetByUsernameAsync(
                dto.Username
            );

        if (existe != null)
        {
            throw new Exception(
                "El usuario ya existe"
            );
        }

        var usuario = new Usuario
        {
            Username = dto.Username,

            // Por ahora sin hash
            PasswordHash = dto.Password,

            Rol = dto.Rol
        };

        return await _repository.CreateAsync(
            usuario
        );
    }

    public async Task<bool> UpdateAsync(
        int id,
        UsuarioUpdateDto dto
    )
    {
        var usuario =
            await _repository.GetByIdAsync(id);

        if (usuario == null)
            return false;

        usuario.Username = dto.Username;
        usuario.Rol = dto.Rol;

        await _repository.UpdateAsync(usuario);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var usuario =
            await _repository.GetByIdAsync(id);

        if (usuario == null)
            return false;

        await _repository.DeleteAsync(usuario);

        return true;
    }
}