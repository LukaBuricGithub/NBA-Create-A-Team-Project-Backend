using BackendForNbaProject.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace BackendForNbaProject.Models.DTO
{
    public class CreateUserDto
    {
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

    }
}
