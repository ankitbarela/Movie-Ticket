namespace WebApplication1.Repository.Theater
{
    public interface ITheaterRepository
    {
        Model.Theater GetById(int id);
        List<Model.Theater> GetAll();
    }
}
