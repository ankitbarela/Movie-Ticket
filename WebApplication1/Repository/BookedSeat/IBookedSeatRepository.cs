namespace WebApplication1.Repository.BookedSeat
{
    public interface IBookedSeatRepository
    {
        Model.BookedSeats Create(Model.BookedSeats bookedSeats);

        List<Model.BookedSeats> GetAll();
    }
}
