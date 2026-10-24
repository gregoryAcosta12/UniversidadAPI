using System.Text.Json.Serialization;
using UniversidadAPI.Entities.Models;

public class Facultad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    // Facultad.cs
    [JsonIgnore]
    public ICollection<Carrera> Carreras { get; set; }
        = new List<Carrera>();
}