using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.City
{
    public class CityRepository : ICityRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.City> entities;

        public CityRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.City>();
        }
        public Model.City Create(Model.City entity)
        {
            throw new NotImplementedException();
        }

        public List<Model.City> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.City GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
