namespace WebApplication1.Repository.City
{
    public interface ICityRepository
    {
        Model.City GetById(int id);
        List<Model.City> GetAll();
        Model.City Create(Model.City city);
    }
}
