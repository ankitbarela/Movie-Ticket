namespace WebApplication1.Services.Seat
{
    public interface ISeatService
    {
        Model.Seat GetById(int id);
        List<Model.Seat> GetAll();
    }
}
