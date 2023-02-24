namespace WebApplication1.Services.BookedSeat
{
    public interface IBookedSeatService
    {
        void Create(List<int> bookedSeats , int showId);
    }
}
