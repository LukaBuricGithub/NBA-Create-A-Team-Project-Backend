using BackendForNbaProject.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendForNbaProject.Models.DTO
{
    public class CreatePlayerDatabaseDto
    {

        public int PlayerJSONID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }
       
        public int TeamID { get; set; }
    }
}
