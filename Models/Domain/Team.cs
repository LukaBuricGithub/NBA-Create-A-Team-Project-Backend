using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendForNbaProject.Models.Domain
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
  
        //[Display(Name = "User")]
        //public virtual int? UserID { get; set; }

        //[ForeignKey("UserID")]
        //public virtual User? User { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserID { get; set; }
        public User? User { get; set; }
        public virtual ICollection<PlayerDatabase>? Players { get; set; }

    }
}
