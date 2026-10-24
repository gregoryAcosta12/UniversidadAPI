using Microsoft.EntityFrameworkCore;
using UniversidadAPI.Entities.Models;

namespace UniversidadAPI.DataAccess.Dbcontext;

public class UniversidadDbContext : DbContext
{
    public UniversidadDbContext(
        DbContextOptions<UniversidadDbContext> options
    ) : base(options)
    {
    }

    public DbSet<Facultad> Facultades { get; set; }

    public DbSet<Carrera> Carreras { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Estudiante> Estudiantes { get; set; }

    public DbSet<Materia> Materias { get; set; }

    public DbSet<Profesor> Profesores { get; set; }

    public DbSet<Inscripcion> Inscripciones { get; set; }

    public DbSet<PeriodoAcademico> Periodos_academicos { get; set; }

    public DbSet<Calificacion> Calificaciones { get; set; }
}