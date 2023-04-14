using Microsoft.EntityFrameworkCore;
using Movie.Entities.Entities;

namespace Movie.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {            
        }

        public DbSet<MovieModel> Films { get; set; }
    }
}
