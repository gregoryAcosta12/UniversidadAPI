using UniversidadAPI.Business.DTOs;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class InscripcionService
    : IInscripcionService
{
    private readonly IInscripcionRepository _repository;

    public InscripcionService(
        IInscripcionRepository repository
    )
    {
        _repository = repository;
    }

    public async Task<List<Inscripcion>>
        GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Inscripcion?>
        GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Inscripcion>
        CreateAsync(
            InscripcionCreateDto dto
        )
    {
        var inscripcion = new Inscripcion
        {
            EstudianteId = dto.EstudianteId,
            MateriaId = dto.MateriaId,
            PeriodoId = dto.PeriodoId
        };

        return await _repository
            .CreateAsync(inscripcion);
    }

    public async Task<bool> UpdateAsync(
        int id,
        InscripcionUpdateDto dto
    )
    {
        var inscripcion =
            await _repository.GetByIdAsync(id);

        if (inscripcion == null)
            return false;

        inscripcion.EstudianteId =
            dto.EstudianteId;

        inscripcion.MateriaId =
            dto.MateriaId;

        inscripcion.PeriodoId =
            dto.PeriodoId;

        await _repository
            .UpdateAsync(inscripcion);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var inscripcion =
            await _repository.GetByIdAsync(id);

        if (inscripcion == null)
            return false;

        await _repository
            .DeleteAsync(inscripcion);

        return true;
    }

    public async Task<List<Inscripcion>> GetByEstudianteIdAsync(int estudianteId)
    {
        return await _repository.GetByEstudianteIdAsync(estudianteId);
    }
}