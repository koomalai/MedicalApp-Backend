using MedicalAppBackend.DTO.UserDto;
using MedicalAppBackend.Models;

namespace MedicalAppBackend.AutoMappers.UserAutoMappers
{
    public static class LoginAutoMappers
    {
        public static User ToUser(this LoginDto loginDto)
        {
            var mapper = BaseAutoMapper.CreateBaseAutoMapper<LoginDto, User>();
            return mapper.Map<User>(loginDto);
        }
    }
}
