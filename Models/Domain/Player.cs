using System.Runtime.Serialization;

namespace BackendForNbaProject.Models.Domain
{
    public class Player 
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        //[DataMember(Name = "height_feet")]
        //public string height_feet { get; set; }

        //[DataMember(Name = "height_inches")]
        //public string height_inches { get; set; }

        [DataMember(Name = "last_name")]
        public string last_name { get; set; }

        [DataMember(Name = "position")]
        public string position { get; set; }
    }
}
