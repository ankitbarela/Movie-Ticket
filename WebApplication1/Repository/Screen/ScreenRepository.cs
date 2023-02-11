using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.Screen
{
    public class ScreenRepository : IScreenRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Screen> entities;

        public ScreenRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.Screen>();
        }

        public List<Model.Screen> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.Screen GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
