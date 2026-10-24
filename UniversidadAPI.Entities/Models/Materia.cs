namespace UniversidadAPI.Entities.Models;

public class Materia
{
    public int Id { get; set; }

    public string Codigo { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public int Creditos { get; set; }
    public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    public int? Profesorid { get; set; }

    public int ProfesorId { get; set; }
    public Profesor? Profesor { get; set; }
}