using AutoMapper;
using RegistrationForm.Common;
using RegistrationForm.DTOs;
using RegistrationForm.Models;
using RegistrationForm.Repositories;
using RegistrationForm.Validators;

namespace RegistrationForm.Services
{
    public class RegistrationService: IRegistrationService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public RegistrationService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<Result<RegistrationResponseDto>> RegisterAsync(RegistrationRequestDto dto)
        {

            if (!DateTime.TryParse(dto.DateOfBirth, out var dob))
                return Result<RegistrationResponseDto>.Failure("Invalid data format");

            if (!RegistrationValidator.IsAdult(dob))
            {
                return Result<RegistrationResponseDto>.Failure("Must be at least 18.");
            }

            if (!RegistrationValidator.IsValidEmail(dto.Email))
            {
                return Result<RegistrationResponseDto>.Failure("Invalid email format.");
            }

            if(dto.Password.Length < 6)
            {
                return Result<RegistrationResponseDto>.Failure("Password must be > 6 chars");
            }

            var user = _mapper.Map<User>(dto);
            await _userRepo.AddAsync(user);

            var response = new RegistrationResponseDto
            {
                Message = "User successfully registered",
                RegisteredAt = DateTime.UtcNow
            };

            return Result<RegistrationResponseDto>.Success(response);
        }

        async Task<Result<List<UserDto>>> IRegistrationService.GetUsersAsync()
        {
            var users = await _userRepo.GetAsync();

            var dtos = _mapper.Map<List<UserDto>>(users);

            return Result<List<UserDto>>.Success(dtos);
        }
    }
}
