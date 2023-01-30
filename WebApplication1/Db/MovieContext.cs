using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Db
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
: base(options)
        {
        }

        public DbSet<Model.City> City { get; set; }
        public DbSet<Model.State> State { get; set; }
        public DbSet<Model.Movie> Movie { get; set; }
        public DbSet<Model.User> User { get; set; }
    }
}
