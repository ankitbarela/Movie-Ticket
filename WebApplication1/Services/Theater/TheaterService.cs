using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Services.Theater
{
    public class TheaterService : ITheaterService
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Theater> entities;

        public TheaterService(MovieContext dbContext)
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
