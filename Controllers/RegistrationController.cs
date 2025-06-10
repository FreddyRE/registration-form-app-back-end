using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.DTOs;
using RegistrationForm.Models;
using RegistrationForm.Repositories;

namespace RegistrationForm.Controllers
{
    [Controller]
    [Route("api/[controller]")]

    public class RegistrationController:ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public RegistrationController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _userRepo.GetAsync();

        }


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] RegistrationRequestDto request)
        {
            var user = _mapper.Map<User>(request);
            await _userRepo.AddAsync(user);
            return Ok(new { message = "User successfully registered"});
        }
    }
}
