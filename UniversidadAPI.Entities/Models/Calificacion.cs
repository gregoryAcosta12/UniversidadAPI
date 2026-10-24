using System.Text.Json.Serialization;

namespace UniversidadAPI.Entities.Models;

public class Calificacion
{
    public int Id { get; set; }

    public int Estudianteid { get; set; }

    public int Materiaid { get; set; }

    public decimal Nota { get; set; }

    public Estudiante? Estudiante { get; set; }


    public Materia? Materia { get; set; }
}