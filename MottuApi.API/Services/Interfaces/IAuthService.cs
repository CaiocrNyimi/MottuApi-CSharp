using MottuApi.API.Dtos;

namespace MottuApi.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegistrarAsync(RegisterRequestDto dto);
        Task<string?> LoginAsync(LoginRequestDto dto);
    }
}