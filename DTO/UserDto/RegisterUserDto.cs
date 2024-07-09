﻿using System.ComponentModel.DataAnnotations;

namespace MedicalAppBackend.DTO.UserDto
{
    public class RegisterUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
