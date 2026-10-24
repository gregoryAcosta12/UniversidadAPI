using UniversidadAPI.Business.DTOs;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class CarreraService : ICarreraService
{
    private readonly ICarreraRepository _repository;
    private readonly IFacultadRepository _facultadRepository;

    public CarreraService(
        ICarreraRepository repository,
        IFacultadRepository facultadRepository)
    {
        _repository = repository;
        _facultadRepository = facultadRepository;
    }

    public async Task<List<Carrera>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Carrera?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Carrera> CreateAsync(
        CarreraCreateDto dto)
    {
        var facultad = await _facultadRepository
            .GetByIdAsync(dto.FacultadId);

        if (facultad == null)
            throw new Exception(
                "La facultad no existe."
            );

        var carrera = new Carrera
        {
            FacultadId = dto.FacultadId,
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            FechaCreacion = DateTime.Now
        };

        return await _repository.CreateAsync(carrera);
    }

    public async Task<bool> UpdateAsync(
        int id,
        CarreraUpdateDto dto)
    {
        var carrera = await _repository.GetByIdAsync(id);

        if (carrera == null)
            return false;

        var facultad = await _facultadRepository
            .GetByIdAsync(dto.FacultadId);

        if (facultad == null)
            throw new Exception(
                "La facultad no existe."
            );

        carrera.FacultadId = dto.FacultadId;
        carrera.Nombre = dto.Nombre;
        carrera.Descripcion = dto.Descripcion;

        await _repository.UpdateAsync(carrera);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var carrera = await _repository.GetByIdAsync(id);

        if (carrera == null)
            return false;

        await _repository.DeleteAsync(carrera);

        return true;
    }
}