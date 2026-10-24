namespace UniversidadAPI.Business.DTOs;

public class CarreraCreateDto
{
    public int FacultadId { get; set; }

    public string Nombre { get; set; }
        = string.Empty;

    public string? Descripcion { get; set; }
}