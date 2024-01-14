using BackendForNbaProject.Models.Domain;

namespace BackendForNbaProject.Repositories.Interface
{
    public interface IPlayerRepository
    {
        Task<Player> GetPlayer(int id);

        Task<ListOfPlayers> GetPlayersByName(string? criteria);
    }
}
