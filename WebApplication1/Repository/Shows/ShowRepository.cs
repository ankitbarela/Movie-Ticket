using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.Show
{
    public class ShowRepository : IShowRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Show> entities;

        public ShowRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.Show>();
        }
        public Model.Show Create(Model.Show entity)
        {
            throw new NotImplementedException();
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
