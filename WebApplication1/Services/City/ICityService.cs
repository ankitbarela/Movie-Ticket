namespace WebApplication1.Services.City
{
    public interface ICityService
    {
        Model.City GetById(int id);
        List<Model.City> GetAll();
    }
}
