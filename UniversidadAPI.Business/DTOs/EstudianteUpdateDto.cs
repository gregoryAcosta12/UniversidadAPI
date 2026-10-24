namespace UniversidadAPI.Business.DTOs;

public class EstudianteUpdateDto
{
    public string Matricula { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public DateTime? FechaNacimiento { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int CarreraId { get; set; }

    public DateTime? FechaIngreso { get; set; }
}