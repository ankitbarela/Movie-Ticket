namespace WebApplication1.Repository.Show
{
    public interface IShowRepository
    {
        Model.Show GetById(int id);
        List<Model.Show> GetAll();
    }
}
