using BackendForNbaProject.Data;
using BackendForNbaProject.Models.Domain;
using BackendForNbaProject.Models.DTO;
using BackendForNbaProject.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackendForNbaProject.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> CreateUser(User user)
        {
            await dbContext.User.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }
    }
}
