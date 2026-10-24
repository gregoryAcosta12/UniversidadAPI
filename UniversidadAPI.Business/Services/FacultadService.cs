using UniversidadAPI.Business.DTOs;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class FacultadService : IFacultadService
{
    private readonly IFacultadRepository _repository;

    public FacultadService(IFacultadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Facultad>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Facultad?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Facultad> CreateAsync(FacultadCreateDto dto)
    {
        var facultad = new Facultad
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion
        };

        return await _repository.CreateAsync(facultad);
    }

    public async Task<bool> UpdateAsync(int id, FacultadUpdateDto dto)
    {
        var facultad = await _repository.GetByIdAsync(id);

        if (facultad == null)
            return false;

        facultad.Nombre = dto.Nombre;
        facultad.Descripcion = dto.Descripcion;

        await _repository.UpdateAsync(facultad);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var facultad = await _repository.GetByIdAsync(id);

        if (facultad == null)
            return false;

        await _repository.DeleteAsync(facultad);

        return true;
    }
}