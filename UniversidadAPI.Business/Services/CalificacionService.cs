using UniversidadAPI.Business.DTOs;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class CalificacionService
    : ICalificacionService
{
    private readonly ICalificacionRepository _repository;

    public CalificacionService(
        ICalificacionRepository repository
    )
    {
        _repository = repository;
    }

    public async Task<List<Calificacion>>
        GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Calificacion?> GetByIdAsync(
        int id
    )
    {
        return await _repository.GetByIdAsync(
            id
        );
    }

    public async Task<Calificacion>
        CreateAsync(
            CalificacionCreateDto dto
        )
    {
        var calificacion =
            new Calificacion
            {
                Estudianteid =
                    dto.Estudianteid,
                Materiaid =
                    dto.Materiaid,
                Nota = dto.Nota
            };

        return await _repository.CreateAsync(
            calificacion
        );
    }

    public async Task<bool> UpdateAsync(
        int id,
        CalificacionUpdateDto dto
    )
    {
        var calificacion =
            await _repository.GetByIdAsync(
                id
            );

        if (calificacion == null)
            return false;

        calificacion.Estudianteid =
            dto.Estudianteid;

        calificacion.Materiaid =
            dto.Materiaid;

        calificacion.Nota =
            dto.Nota;

        await _repository.UpdateAsync(
            calificacion
        );

        return true;
    }
    public async Task<List<Calificacion>> GetByEstudianteIdAsync(int estudianteId)
    {
        return await _repository.GetByEstudianteIdAsync(estudianteId);
    }
    public async Task<bool> DeleteAsync(
        int id
    )
    {
        var calificacion =
            await _repository.GetByIdAsync(
                id
            );

        if (calificacion == null)
            return false;

        await _repository.DeleteAsync(
            calificacion
        );

        return true;
    }
}