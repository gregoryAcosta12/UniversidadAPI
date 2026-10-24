using System.Text.Json.Serialization;

namespace UniversidadAPI.Entities.Models;

public class Profesor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Especialidad { get; set; }

    [JsonIgnore]
    public ICollection<Materia> Materias { get; set; } = new List<Materia>();

    public int UsuarioId { get; set; }

    [JsonIgnore]
    public Usuario? Usuario { get; set; }
}