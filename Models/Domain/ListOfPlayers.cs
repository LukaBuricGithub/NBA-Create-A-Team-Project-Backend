using System.Runtime.Serialization;

namespace BackendForNbaProject.Models.Domain
{
    public class ListOfPlayers
    {
        [DataMember(Name = "data")]
        public List<Player>? data { get; set; }
    }
}
