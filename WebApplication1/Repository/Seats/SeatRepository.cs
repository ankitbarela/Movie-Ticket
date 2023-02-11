using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.Seat
{
    public class SeatRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Seat> entities;

        public SeatRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.Seat>();
        }

        public List<Model.Seat> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.Seat GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
