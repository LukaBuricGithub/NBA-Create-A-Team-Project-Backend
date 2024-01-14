using BackendForNbaProject.Data;
using BackendForNbaProject.Models.Domain;
using BackendForNbaProject.Models.DTO;
using BackendForNbaProject.Repositories.Implementation;
using BackendForNbaProject.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace BackendForNbaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository playerRepository;
        private readonly ApplicationDbContext dbContext;
        public PlayerController(IPlayerRepository playerRepository, ApplicationDbContext dbContext)
        {
            this.playerRepository = playerRepository;
            this.dbContext = dbContext;
        }

        [HttpGet("get-player")]
        public async Task<ActionResult> GetPlayer(int id)
        {
            var result = await playerRepository.GetPlayer(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("get-players-by-name")]
        public async Task<ActionResult> GetPlayersByName(string? criteria)
        {
            var result = await playerRepository.GetPlayersByName(criteria);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost("InsertPlayeDatabase")]
        public async Task<IActionResult> InsertPlayeDatabase(CreatePlayerDatabaseDto request)
        {

            var player = new PlayerDatabase
            {
                PlayerJSONID = request.PlayerJSONID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Position = request.Position,
                TeamID = request.TeamID,
            };

            await this.dbContext.PlayerDatabase.AddAsync(player);
            await this.dbContext.SaveChangesAsync();

            var response = new PlayerDatabaseDto
            {
                PlayerID = player.PlayerID,
                PlayerJSONID = player.PlayerJSONID,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Position = player.Position,
                TeamID = player.TeamID
            };

            return Ok(response);
        }



        [HttpGet("GetAllPlayersInTeam")]
        public IActionResult GetAllPlayersInTeam(int teamId)
        {
            var players = dbContext.PlayerDatabase.Where(p => p.TeamID == teamId).Select(p => new PlayerDatabaseDto()
            {
                PlayerID = p.PlayerID,
                PlayerJSONID = p.PlayerJSONID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Position = p.Position,
                TeamID = p.TeamID
            }).ToList();
            return Ok(players);
        }

        [HttpPut("UpdatePlayer")]
        public async Task<IActionResult> UpdatePlayer(PlayerDatabaseDto request)
        {
            var existingPlayer = await dbContext.PlayerDatabase.FindAsync(request.PlayerID);

            if (existingPlayer == null)
            {
                return NotFound();
            }

            existingPlayer.PlayerID = request.PlayerID;
            existingPlayer.PlayerJSONID = request.PlayerJSONID;
            existingPlayer.FirstName= request.FirstName;
            existingPlayer.LastName= request.LastName;
            existingPlayer.Position= request.Position;
            existingPlayer.TeamID = request.TeamID;

            await dbContext.SaveChangesAsync();

            // Return the updated user


            var updatedPlayer = new PlayerDatabaseDto
            {
                PlayerID=existingPlayer.PlayerID,
                PlayerJSONID=existingPlayer.PlayerJSONID,
                FirstName=existingPlayer.FirstName,
                LastName=existingPlayer.LastName,
                Position=existingPlayer.Position,
                TeamID=existingPlayer.TeamID
            };

            return Ok(updatedPlayer);
        }
    }
}
