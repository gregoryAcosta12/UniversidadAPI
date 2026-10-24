using UniversidadAPI.Business.DTOs;
using UniversidadAPI.Business.Helpers;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class PeriodoAcademicoService : IPeriodoAcademicoService
{
    private readonly IPeriodoAcademicoRepository _repository;

    public PeriodoAcademicoService(IPeriodoAcademicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PeriodoAcademicoResponseDto>> GetAllAsync()
    {
        var periodos = await _repository.GetAllAsync();

        var resultado = new List<PeriodoAcademicoResponseDto>();

        foreach (var p in periodos)
        {
            resultado.Add(new PeriodoAcademicoResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                FechaInicio = DateHelper.FormatearFechaParaFrontend(p.FechaInicio),
                FechaFin = DateHelper.FormatearFechaParaFrontend(p.FechaFin)
            });
        }

        return resultado;
    }

    public async Task<PeriodoAcademicoResponseDto?> GetByIdAsync(int id)
    {
        var periodo = await _repository.GetByIdAsync(id);

        if (periodo == null)
            return null;

        return new PeriodoAcademicoResponseDto
        {
            Id = periodo.Id,
            Nombre = periodo.Nombre,
            FechaInicio = DateHelper.FormatearFechaParaFrontend(periodo.FechaInicio),
            FechaFin = DateHelper.FormatearFechaParaFrontend(periodo.FechaFin)
        };
    }

    public async Task<PeriodoAcademico> CreateAsync(PeriodoAcademicoCreateDto dto)
    {
        var periodo = new PeriodoAcademico
        {
            Nombre = dto.Nombre,
            FechaInicio = dto.FechaInicio,
            FechaFin = dto.FechaFin
        };

        return await _repository.CreateAsync(periodo);
    }

    public async Task<bool> UpdateAsync(int id, PeriodoAcademicoUpdateDto dto)
    {
        var periodo = await _repository.GetByIdAsync(id);

        if (periodo == null)
            return false;

        periodo.Nombre = dto.Nombre;
        periodo.FechaInicio = dto.FechaInicio;
        periodo.FechaFin = dto.FechaFin;

        await _repository.UpdateAsync(periodo);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var periodo = await _repository.GetByIdAsync(id);

        if (periodo == null)
            return false;

        await _repository.DeleteAsync(periodo);

        return true;
    }
}