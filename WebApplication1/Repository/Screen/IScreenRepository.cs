namespace WebApplication1.Repository.Screen
{
    public interface IScreenRepository
    {
        Model.Screen GetById(int id);
        List<Model.Screen> GetAll();
    }
}
