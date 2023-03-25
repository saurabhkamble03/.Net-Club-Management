using Club.Models;
using Microsoft.EntityFrameworkCore;

namespace Club.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Squad> Squads { get; set; }
    }
}
