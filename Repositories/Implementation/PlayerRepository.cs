using BackendForNbaProject.Data;
using BackendForNbaProject.Models.Domain;
using BackendForNbaProject.Repositories.Interface;
using Newtonsoft.Json;

namespace BackendForNbaProject.Repositories.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PlayerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }

        public async Task<Player> GetPlayer(int id)
        {
            //throw new NotImplementedException();
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://www.balldontlie.io/api/v1/players/{id}");

                var response = await client.GetAsync(url);

                string json;

                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<Player>(json);
            }
        }

        public async Task<ListOfPlayers> GetPlayersByName(string? criteria)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://www.balldontlie.io/api/v1/players?search={criteria}");

                var response = await client.GetAsync(url);

                string json;

                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                //var data = JsonConvert.DeserializeObject<List<Models.ListOfPlayers>>(json);
                //List<Models.SubProjectViewRecord> oop = JsonConvert.DeserializeObject<List<Models.SubProjectViewRecord>>(objJson);
                //return JsonConvert.DeserializeObject<List<Player>>(json);
                return JsonConvert.DeserializeObject<ListOfPlayers>(json);


            }
        }
    }
}
