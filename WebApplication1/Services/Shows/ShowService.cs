using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Services.Show
{
    public class ShowService : IShowService
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Show> entities;

        public ShowService(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.Show>();
        }

        public List<Model.Show> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.Show GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
