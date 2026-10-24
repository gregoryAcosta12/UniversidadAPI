namespace UniversidadAPI.Entities.Models;

public class Inscripcion
{
    public int Id { get; set; }

    public int EstudianteId { get; set; }

    public int MateriaId { get; set; }

    public int PeriodoId { get; set; }

    public DateTime? FechaInscripcion { get; set; }

    public Estudiante? Estudiante { get; set; }

    public PeriodoAcademico? PeriodoAcademico { get; set; }

    public Materia? Materia { get; set; }

    public PeriodoAcademico? Periodo { get; set; }
}