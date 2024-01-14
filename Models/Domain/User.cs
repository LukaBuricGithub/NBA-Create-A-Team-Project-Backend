using System.ComponentModel.DataAnnotations;

namespace BackendForNbaProject.Models.Domain
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Team>? Teams { get; set; }
    }
}
