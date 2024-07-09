using AutoMapper;
using MedicalAppBackend.DTO.UserDto;
using MedicalAppBackend.Models;

namespace MedicalAppBackend.AutoMappers.UserAutoMappers
{
    public static class RegisterAutoMappers
    {
        public static User ToUser(this RegisterUserDto registerUserDto)
        {
            var configuration = new MapperConfiguration(configuration =>
                configuration.CreateMap<RegisterUserDto, User>()
                .ForMember(destination =>
                destination.Password,
                confirmPassword => confirmPassword.MapFrom(source => source.ConfirmPassword == source.Password))
                 .ForMember(destination =>
                destination.Password,
                BCryptPassword => BCryptPassword.MapFrom(source => BCrypt.Net.BCrypt.HashPassword(source.Password)))
                .ForMember(destination =>
                destination.CreatedOn,
                createdDate => createdDate.MapFrom(source => DateTime.Today))
                .ForMember(destination =>
                destination.UserType,
                userType => userType.MapFrom(source => "User"))
                .ForMember(destination =>
                destination.Status,
                status => status.MapFrom(source => 0))
            );
            var mapper = new Mapper(configuration);
            return mapper.Map<User>(registerUserDto);
        }
    }
}
