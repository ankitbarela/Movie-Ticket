using WebApplication1.Model;
using WebApplication1.Repository.BookedSeat;
using WebApplication1.Repository.BookingSummary;

namespace WebApplication1.Services.BookedSeat
{
    public class BookedSeatService : IBookedSeatService
    {
        private readonly IBookedSeatRepository bookedSeatRepository;

        public BookedSeatService(IBookedSeatRepository bookedSeatRepository)
        {
            this.bookedSeatRepository = bookedSeatRepository;
        }

        public List<Model.BookedSeats> GetAll()
        {
            return bookedSeatRepository.GetAll();
        }
        public void Create(List<int> bookedSeats , int showId)
        {
            var bookSeats = new Model.BookedSeats();
            foreach (var booked in bookedSeats)
            {
                bookSeats.BokeedSeatNumber = booked;
                bookSeats.ShowId = showId;
                bookSeats.BokeedSeatId = 0;
                bookedSeatRepository.Create(bookSeats);
            }
        }
    }
}
