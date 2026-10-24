using UniversidadAPI.Business.DTOs;

namespace UniversidadAPI.Business.Services;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginDto dto);
}