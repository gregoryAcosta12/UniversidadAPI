using UniversidadAPI.Business.DTOs;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class ProfesorService : IProfesorService
{
    private readonly IProfesorRepository _repository;

    public ProfesorService(
        IProfesorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Profesor>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Profesor?> GetByIdAsync(
        int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Profesor> CreateAsync(
        ProfesorCreateDto dto)
    {
        var profesor = new Profesor
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Correo = dto.Correo,
            Telefono = dto.Telefono,
            Especialidad = dto.Especialidad
        };

        return await _repository.CreateAsync(profesor);
    }

    public async Task<List<Materia>> GetMateriasByProfesorIdAsync(int profesorId)
    {
        return await _repository.GetMateriasByProfesorIdAsync(profesorId);
    }

    public async Task<Profesor?> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _repository.GetByUsuarioIdAsync(usuarioId);
    }
    public async Task<bool> UpdateAsync(
        int id,
        ProfesorUpdateDto dto)
    {
        var profesor =
            await _repository.GetByIdAsync(id);

        if (profesor == null)
            return false;

        profesor.Nombre = dto.Nombre;
        profesor.Apellido = dto.Apellido;
        profesor.Correo = dto.Correo;
        profesor.Telefono = dto.Telefono;
        profesor.Especialidad = dto.Especialidad;

        await _repository.UpdateAsync(profesor);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var profesor =
            await _repository.GetByIdAsync(id);

        if (profesor == null)
            return false;

        await _repository.DeleteAsync(profesor);

        return true;
    }
}