using BackendForNbaProject.Data;
using BackendForNbaProject.Models.Domain;
using BackendForNbaProject.Models.DTO;
using BackendForNbaProject.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendForNbaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        private readonly ApplicationDbContext dbContext;

        public UserController(IUserRepository userRepository, ApplicationDbContext dbContext)
        {
            this.userRepository = userRepository;
            this.dbContext = dbContext;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto request) 
        {

            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                IsActive = request.IsActive,
                IsAdmin = request.IsAdmin,
            };

            await userRepository.CreateUser(user);

            var response = new UserDto
            {
                UserID = user.UserID,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                IsActive = user.IsActive,
                IsAdmin = user.IsAdmin
            };

            return Ok(response);
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int userId)
        {
            var usr = dbContext.User.Where(d => d.UserID == userId).Select(d => new UserDto()
            {
                UserID = d.UserID,
                Email = d.Email,
                Username = d.Username,
                Password = d.Password,
                IsActive = d.IsActive,
                IsAdmin = d.IsAdmin,
            }).FirstOrDefault();

            if(usr == null) 
            { 
                return NotFound();
            }

            return Ok(usr); 
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var usrs = this.dbContext.User.Select(u => new UserDto()
            {
                UserID = u.UserID,
                Email = u.Email,
                Username = u.Username,
                Password = u.Password,
                IsActive = u.IsActive,
                IsAdmin = u.IsAdmin,

            }).ToList();

            return Ok(usrs);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDto request)
        {
            var existingUser = await dbContext.User.FindAsync(request.UserID);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the properties you want to allow modification
            existingUser.Email = request.Email;
            existingUser.Username = request.Username;
            existingUser.Password = request.Password;
            existingUser.IsActive = request.IsActive;
            existingUser.IsAdmin = request.IsAdmin;

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Return the updated user
            var updatedUser = new UserDto
            {
                UserID = existingUser.UserID,
                Email = existingUser.Email,
                Username = existingUser.Username,
                Password = existingUser.Password,
                IsActive = existingUser.IsActive,
                IsAdmin = existingUser.IsAdmin
            };

            return Ok(updatedUser);
        }



        [HttpPut("ChangeUserToActiveOrDeactive")]
        public async Task<IActionResult> ChangeUserToActiveOrDeactive(int userID)
        {
            var existingUser = await dbContext.User.FindAsync(userID);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the properties you want to allow modification
            if(existingUser.IsActive == true) 
            { 
                existingUser.IsActive = false;
            }
            else 
            { 
                existingUser.IsActive= true;
            }

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Return the updated user
            var updatedUser = new UserDto
            {
                UserID = existingUser.UserID,
                Email = existingUser.Email,
                Username = existingUser.Username,
                Password = existingUser.Password,
                IsActive = existingUser.IsActive,
                IsAdmin = existingUser.IsAdmin
            };

            return Ok(updatedUser);
        }

        [HttpGet("UserLogin")]
        public IActionResult UserLogin(string email,string password)
        {
            var usr = dbContext.User.Where(d => (d.Email == email) && (d.Password == password) ).Select(d => new UserDto()
            {
                UserID = d.UserID,
                Email = d.Email,
                Username = d.Username,
                Password = d.Password,
                IsActive = d.IsActive,
                IsAdmin = d.IsAdmin,
            }).FirstOrDefault();

            if (usr.IsActive == false) 
            {
                return NotFound();
            }

            if (usr == null)
            {
                return NotFound();
                //return Ok(null);
            }
            return Ok(usr);
        }



    }
}
