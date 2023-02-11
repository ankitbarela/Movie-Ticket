namespace WebApplication1.Repository.Seat
{
    public interface ISeatRepository
    {
        Model.Seat GetById(int id);
        List<Model.Seat> GetAll();
    }
}
