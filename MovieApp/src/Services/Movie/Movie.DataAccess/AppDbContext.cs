using Microsoft.EntityFrameworkCore;
using Movie.Entities.Entities;

namespace Movie.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
