namespace UniversidadAPI.Business.DTOs;

public class PeriodoAcademicoResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string FechaInicio { get; set; } = string.Empty; 
    public string FechaFin { get; set; } = string.Empty;    
}