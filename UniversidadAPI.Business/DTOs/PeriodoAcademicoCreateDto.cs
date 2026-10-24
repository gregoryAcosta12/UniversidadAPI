namespace UniversidadAPI.Business.DTOs;

public class PeriodoAcademicoCreateDto
{
    public string Nombre { get; set; } = string.Empty;

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }
}