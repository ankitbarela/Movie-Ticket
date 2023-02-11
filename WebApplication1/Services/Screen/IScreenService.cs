namespace WebApplication1.Services.Screen
{
    public interface IScreenService
    {
        Model.Screen GetById(int id);
        List<Model.Screen> GetAll();
    }
}
