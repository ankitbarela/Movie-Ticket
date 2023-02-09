namespace WebApplication1.Repository.Movie
{
    public interface IMovieRepository
    {
        Model.Movie GetById(int id);
        List<Model.Movie> GetAll();
    }
}
