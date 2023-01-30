using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.User> entities;

        public UserRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.User>();
        }

        public Model.User Authenticate(string userName, string password)
        {
            return dbContext.User.FirstOrDefault(x => x.Name == userName && x.Password == password);
        }

        public Model.User Create(Model.User user)
        {
            this.dbContext.Add(user);
            this.dbContext.SaveChanges();
            return user;
        }

        public List<Model.User> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.User GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
