namespace UniversidadAPI.Business.DTOs;

public class UsuarioCreateDto
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Rol { get; set; } = string.Empty;
}