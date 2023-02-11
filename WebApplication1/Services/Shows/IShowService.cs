namespace WebApplication1.Services.Show
{
    public interface IShowService
    {
        Model.Show GetById(int id);
        List<Model.Show> GetAll();
    }
}
