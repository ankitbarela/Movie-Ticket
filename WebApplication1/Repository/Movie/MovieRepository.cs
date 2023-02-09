using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.Movie
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Movie> entities;
        public MovieRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.Movie>();
        }
        public List<Model.Movie> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.Movie GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
