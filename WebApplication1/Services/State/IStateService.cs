namespace WebApplication1.Services.State
{
    public interface IStateService
    {
        Model.State GetById(int id);
        List<Model.State> GetAll();
    }
}
