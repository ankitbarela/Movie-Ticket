using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.Payment
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Payment> entities;
        public PaymentRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<Model.Payment>();
        }
        public List<Model.Payment> GetAll()
        {
            return entities.AsQueryable().ToList();    
        }

        public Model.Payment Create(Model.Payment payment)
        {
            dbContext.Add(payment);
            dbContext.SaveChanges();
            return payment;
        }

        public Model.Payment Get(int id)
        {
            return entities.Find(id);
        }
    }
}
