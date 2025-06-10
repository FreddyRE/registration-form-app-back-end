using RegistrationForm.Common;
using RegistrationForm.DTOs;

namespace RegistrationForm.Services
{
    public interface IRegistrationService
    {
        Task<Result<RegistrationResponseDto>> RegisterAsync(RegistrationRequestDto dto);
        Task<Result<List<UserDto>>> GetUsersAsync();
    }
}
