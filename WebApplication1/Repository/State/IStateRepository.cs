namespace WebApplication1.Repository.State
{
    public interface IStateRepository
    {
        Model.State GetById(int id);
        List<Model.State> GetAll();
    }
}
