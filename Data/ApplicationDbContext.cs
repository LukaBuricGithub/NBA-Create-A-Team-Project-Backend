using BackendForNbaProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BackendForNbaProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Team> Team {  get; set; }
        public DbSet<PlayerDatabase> PlayerDatabase { get; set; }
    }
}
