using System.Data.Entity;
using WebApplication1.Db;
using WebApplication1.Model;

namespace WebApplication1.Repository.BookedSeat
{
    public class BookedSeatRepository : IBookedSeatRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.BookedSeats> entities;

        public BookedSeatRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public BookedSeats Create(BookedSeats bookedSeats)
        {
            dbContext.Add(bookedSeats);
            dbContext.SaveChanges();
            return bookedSeats;
        }
    }
}
