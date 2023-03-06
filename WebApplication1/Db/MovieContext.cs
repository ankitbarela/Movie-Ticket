using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Db
{
    public class MovieContext : DbContext
    {
        public MovieContext()
        {

        }
        public MovieContext(DbContextOptions<MovieContext> options)
: base(options)
        {
        }

        public DbSet<Model.City> City { get; set; }
        public DbSet<Model.State> State { get; set; }
        public DbSet<Model.Movie> Movie { get; set; }
        public DbSet<Model.User> User { get; set; }
        public DbSet<Model.LoginCredential> loginCredential { get; set; }
        public DbSet<Model.Screen> Screen { get; set; }
        public DbSet<Model.Show> Show { get; set; }
        public DbSet<Model.Theater> Theater { get; set; }
        public DbSet<Model.Seat> Seat { get; set; }
        public DbSet<Model.BookingSummary> BookingSummary { get; set; }
        public DbSet<Model.BookedSeats> BookedSeats { get; set; }
        public DbSet<Model.Payment> Payment { get; set; }
    }
}
