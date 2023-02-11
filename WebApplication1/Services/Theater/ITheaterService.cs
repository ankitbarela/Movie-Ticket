namespace WebApplication1.Services.Theater
{
    public interface ITheaterService
    {
        Model.Theater GetById(int id);
        List<Model.Theater> GetAll();
    }
}
