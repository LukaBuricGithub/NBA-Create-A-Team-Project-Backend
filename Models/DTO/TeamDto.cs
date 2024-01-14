using BackendForNbaProject.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendForNbaProject.Models.DTO
{
    public class TeamDto
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }

        //[Display(Name = "User")]
        //public virtual int? UserID { get; set; }

        //[ForeignKey("UserID")]
        //public virtual User? User { get; set; }
        public int? UserID { get; set; }
    }
}
