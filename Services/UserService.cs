using MedicalAppBackend.Context;
using MedicalAppBackend.DTO.UserDto;
using MedicalAppBackend.Interfaces;
using MedicalAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class UserService : IUserServices
    {
        private readonly MedicineAppDatabaseContext _medicineContext;

        public UserService(MedicineAppDatabaseContext medicineContext)
        {
            _medicineContext = medicineContext;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            if (_medicineContext.Users.Any(u => u.Email == user.Email))
            {
                return false;
            }

            _medicineContext.Users.Add(user);
            await _medicineContext.SaveChangesAsync();

            if (user != null)
            {
                return true;
            }
            return false;
        }

        //Login user and update status to 1
        public async Task<User?> LoginUserAsync(LoginDto loginDto, HttpContext httpContext)
        {
            var userDetails = await _medicineContext.Users.FirstOrDefaultAsync(email => email.Email == loginDto.Email);

            if (userDetails == null)
                return null;

            var checkValidPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, userDetails!.Password);
            if (!checkValidPassword)
            {
                return null;
            }

            if (!httpContext!.User!.Identity!.IsAuthenticated)
            {
                userDetails.Status = 1;
                await _medicineContext.SaveChangesAsync();
            }
            else
            {
                userDetails.Status = 0;
                await _medicineContext.SaveChangesAsync();
            }

            return userDetails;
        }
    }
}
