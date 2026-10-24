using UniversidadAPI.Business.DTOs;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class MateriaService : IMateriaService
{
    private readonly IMateriaRepository _repository;

    public MateriaService(
        IMateriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Materia>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Materia?> GetByIdAsync(
        int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<List<Materia>> GetByEstudianteIdAsync(int estudianteId)
    {
        return await _repository.GetByEstudianteIdAsync(estudianteId);
    }

    public async Task<Materia> CreateAsync(
        MateriaCreateDto dto)
    {
        var materia = new Materia
        {
            Codigo = dto.Codigo,
            Nombre = dto.Nombre,
            Creditos = dto.Creditos,
            Profesorid = dto.Profesorid
        };

        return await _repository.CreateAsync(
            materia);
    }

    public async Task<bool> UpdateAsync(
        int id,
        MateriaUpdateDto dto)
    {
        var materia =
            await _repository.GetByIdAsync(id);

        if (materia == null)
            return false;

        materia.Codigo = dto.Codigo;
        materia.Nombre = dto.Nombre;
        materia.Creditos = dto.Creditos;
        materia.Profesorid = dto.Profesorid;

        await _repository.UpdateAsync(materia);

        return true;
    }

    public async Task<bool> DeleteAsync(
        int id)
    {
        var materia =
            await _repository.GetByIdAsync(id);

        if (materia == null)
            return false;

        await _repository.DeleteAsync(materia);

        return true;
    }
}