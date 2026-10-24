namespace UniversidadAPI.Entities.Models;

public class Carrera
{
    public int Id { get; set; }

    public int FacultadId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public Facultad? Facultad { get; set; }
}