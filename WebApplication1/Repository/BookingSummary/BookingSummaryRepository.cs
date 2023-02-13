using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.BookingSummary
{
    public class BookingSummaryRepository : IBookingSummaryRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.BookingSummary> entities;

        public BookingSummaryRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Model.BookingSummary Create(Model.BookingSummary bookingSummary)
        {
            dbContext.Add(bookingSummary);  
            dbContext.SaveChanges();
            return bookingSummary;
        }
    }
}
