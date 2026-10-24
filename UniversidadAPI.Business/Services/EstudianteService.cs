using UniversidadAPI.Business.DTOs;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.Business.Services;

public class EstudianteService
    : IEstudianteService
{
    private readonly IEstudianteRepository _repository;
    private readonly ICarreraRepository _carreraRepository;

    public EstudianteService(
        IEstudianteRepository repository,
        ICarreraRepository carreraRepository)
    {
        _repository = repository;
        _carreraRepository = carreraRepository;
    }

    public async Task<List<Estudiante>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Estudiante?> GetByIdAsync(
        int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Estudiante> CreateAsync(
        EstudianteCreateDto dto)
    {
        var carrera =
            await _carreraRepository
                .GetByIdAsync(dto.CarreraId);

        if (carrera == null)
            throw new Exception(
                "La carrera no existe");

        var estudiante = new Estudiante
        {
            Matricula = dto.Matricula,
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            FechaNacimiento =
                dto.FechaNacimiento,
            Correo = dto.Correo,
            Telefono = dto.Telefono,
            Direccion = dto.Direccion,
            CarreraId = dto.CarreraId,
            FechaIngreso =
                dto.FechaIngreso
        };

        return await _repository
            .CreateAsync(estudiante);
    }

    public async Task<bool> UpdateAsync(
        int id,
        EstudianteUpdateDto dto)
    {
        var estudiante =
            await _repository.GetByIdAsync(id);

        if (estudiante == null)
            return false;

        estudiante.Matricula =
            dto.Matricula;

        estudiante.Nombre =
            dto.Nombre;

        estudiante.Apellido =
            dto.Apellido;

        estudiante.FechaNacimiento =
            dto.FechaNacimiento;

        estudiante.Correo =
            dto.Correo;

        estudiante.Telefono =
            dto.Telefono;

        estudiante.Direccion =
            dto.Direccion;

        estudiante.CarreraId =
            dto.CarreraId;

        estudiante.FechaIngreso =
            dto.FechaIngreso;

        await _repository.UpdateAsync(
            estudiante);

        return true;
    }
    public async Task<Estudiante?> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _repository.GetByUsuarioIdAsync(usuarioId);
    }
    public async Task<bool> DeleteAsync(
        int id)
    {
        var estudiante =
            await _repository.GetByIdAsync(id);

        if (estudiante == null)
            return false;

        await _repository.DeleteAsync(
            estudiante);

        return true;
    }
}