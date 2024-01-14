using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendForNbaProject.Models.Domain
{
    public class PlayerDatabase
    {


        [Key]
        public int PlayerID { get; set; }

        public int PlayerJSONID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamID { get; set; }
        public Team? Team { get; set; }
    }
}
