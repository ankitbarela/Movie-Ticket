using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.Theater
{
    public class TheaterRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Theater> entities;

        public TheaterRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.Theater>();
        }

        public List<Model.Theater> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.Theater GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
