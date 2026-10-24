namespace UniversidadAPI.Business.DTOs;

public class MateriaUpdateDto
{
    public string Codigo { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public int Creditos { get; set; }

    public int? Profesorid { get; set; }
}