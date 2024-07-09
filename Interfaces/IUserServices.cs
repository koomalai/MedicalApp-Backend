using MedicalAppBackend.DTO.UserDto;
using MedicalAppBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Interfaces
{
    public interface IUserServices
    {
        public Task<bool> RegisterUserAsync(User user);
        public Task<User?> LoginUserAsync(LoginDto loginDto, HttpContext httpContext);
    }
}
