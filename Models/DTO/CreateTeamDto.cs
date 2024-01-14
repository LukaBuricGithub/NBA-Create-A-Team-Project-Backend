using BackendForNbaProject.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendForNbaProject.Models.DTO
{
    public class CreateTeamDto
    {
        public string TeamName { get; set; }

        public virtual int UserID { get; set; }

    }
}
