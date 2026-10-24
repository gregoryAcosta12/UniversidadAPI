namespace UniversidadAPI.Business.DTOs;

public class ProfesorUpdateDto
{
    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Especialidad { get; set; }
}