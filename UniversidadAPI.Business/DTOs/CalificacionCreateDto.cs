namespace UniversidadAPI.Business.DTOs;

public class CalificacionCreateDto
{
    public int Estudianteid { get; set; }

    public int Materiaid { get; set; }

    public decimal Nota { get; set; }
}