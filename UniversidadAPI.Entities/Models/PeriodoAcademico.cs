namespace UniversidadAPI.Entities.Models;

public class PeriodoAcademico
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }
}