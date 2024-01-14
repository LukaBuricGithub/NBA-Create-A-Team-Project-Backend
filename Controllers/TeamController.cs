using BackendForNbaProject.Data;
using BackendForNbaProject.Models.Domain;
using BackendForNbaProject.Models.DTO;
using BackendForNbaProject.Repositories.Implementation;
using BackendForNbaProject.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendForNbaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public TeamController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        [HttpPost("CreateTeam")]
        public async Task<IActionResult> CreateTeam([FromBody]CreateTeamDto request)
        {
            var user = this.dbContext.User.FirstOrDefault(u => u.UserID == request.UserID);

            var team = new Team
            {
                TeamName = request.TeamName,
                UserID = request.UserID,
                User=user
            };

            await this.dbContext.Team.AddAsync(team);
            await this.dbContext.SaveChangesAsync();

            var response = new TeamDto
            {
                TeamID = team.TeamID,
                TeamName=team.TeamName,
                UserID=team.UserID
            };
             return Ok(response);
        }
        [HttpGet("LastInsertedTeam")]
        public async Task<IActionResult> LastInsertedTeam() 
        { 
            var team1 = this.dbContext.Team.OrderBy(t =>t.TeamID).LastOrDefault();
            var team2 = new TeamDto
            {
                TeamID=team1.TeamID,
                TeamName=team1.TeamName,
                UserID=team1.UserID
            };
            return Ok(team2.TeamID);
            /*
             var usrs = this.dbContext.User.Select(u => new UserDto()
             {
                 UserID = u.UserID,
                 Email = u.Email,
                 Username = u.Username,
                 Password = u.Password,
                 IsActive = u.IsActive,
                 IsAdmin = u.IsAdmin,

             }).ToList();*/
        }


        [HttpPut("UpdateTeam")]
        public async Task<IActionResult> UpdateTeam(TeamDto request)
        {
            var existingTeam = await dbContext.Team.FindAsync(request.TeamID);

            if (existingTeam == null)
            {
                return NotFound();
            }

            existingTeam.TeamName=request.TeamName;
            existingTeam.UserID=request.UserID;

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Return the updated user
            var updatedTeam = new TeamDto
            {
                TeamID = existingTeam.TeamID,
                TeamName = existingTeam.TeamName,
                UserID = existingTeam.UserID
            };

            return Ok(updatedTeam);
        }


        [HttpGet("GetAllTeams")]
        public IActionResult GetAllTeams()
        {
            var teams = this.dbContext.Team.Select(t => new TeamDto()
            {

                TeamID=t.TeamID,
                TeamName=t.TeamName,
                UserID=t.UserID
            }).ToList();

            return Ok(teams);
        }


        [HttpGet("GetAllTeamsFromUserID")]
        public IActionResult GetAllTeamsFromUserID(int userId)
        {
            //teams = this.dbContext.Team.Select(t => new TeamDto()
            //{
                //TeamID = t.TeamID,
                //TeamName = t.TeamName,
              //  UserID = t.UserID
            //}).ToList();
            var teams = dbContext.Team.Where(t => t.UserID == userId).Select(t => new TeamDto()
            {
                TeamID = t.TeamID,
                TeamName = t.TeamName,
                UserID = t.UserID
            }).ToList();

            return Ok(teams);
        }

        [HttpGet("GetTeamByID")]
        public IActionResult GetTeamByID(int teamID)
        {
            var team = dbContext.Team.Where(t => t.TeamID == teamID).Select(t => new TeamDto()
            {
                TeamID = t.TeamID,
                TeamName = t.TeamName,
                UserID = t.UserID
            }).FirstOrDefault();

            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
        [HttpDelete("DeleteTeamByID")]
        public IActionResult DeleteTeamByID(int teamID)
        {

            var playersToDelete = dbContext.PlayerDatabase.Where(p => p.TeamID == teamID);
            dbContext.PlayerDatabase.RemoveRange(playersToDelete);
            dbContext.SaveChanges();



            var teamToDelete = dbContext.Team.FirstOrDefault(t => t.TeamID == teamID);
            dbContext.Team.Remove(teamToDelete);
            dbContext.SaveChanges();

            //if (teamToDelete == null)
            //{
            //return NotFound("Team not found");
            //}

            return Ok();
        }

    }
}
