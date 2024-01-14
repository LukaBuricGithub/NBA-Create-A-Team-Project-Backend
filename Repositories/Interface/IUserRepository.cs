using BackendForNbaProject.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BackendForNbaProject.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        //Task<User> SelectUser(int userId);
    }
}
