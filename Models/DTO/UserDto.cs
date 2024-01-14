using BackendForNbaProject.Models.Domain;

namespace BackendForNbaProject.Models.DTO
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

    }
}
