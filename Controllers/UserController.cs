using MedicalAppBackend.AutoMappers.UserAutoMappers;
using MedicalAppBackend.DTO.UserDto;
using MedicalAppBackend.Interfaces;
using MedicalAppBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;

namespace MedicalAppBackend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("api/user/register")]
        public async Task<bool> UserRegistrationAsync([FromBody] RegisterUserDto registerUserDto)
        {
            var users = registerUserDto.ToUser();

            return await _userService.RegisterUserAsync(users);
        }

        [HttpPost]
        [Route("api/user/login")]
        public async Task<User?> LoginUserAsync([FromBody] LoginDto loginDto)
        {
            return await _userService.LoginUserAsync(loginDto, HttpContext);
        }
    }
}
