using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.DTOs;
using RegistrationForm.Models;
using RegistrationForm.Repositories;
using RegistrationForm.Services;

namespace RegistrationForm.Controllers
{
    [Controller]
    [Route("api/[controller]")]

    public class RegistrationController:ControllerBase
    {
        private readonly IRegistrationService _service;
   
        public RegistrationController(IRegistrationService service)
        {
            _service = service;
       }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _service.GetUsersAsync();
            if(!result.IsSuccess)
            {
                return BadRequest(new { errors = result.Error });
            }

            return Ok(result);

        }


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] RegistrationRequestDto request)
        {
            var result = await _service.RegisterAsync(request);
            return Ok(result);
        }
    }
}
