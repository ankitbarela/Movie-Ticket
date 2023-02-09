namespace WebApplication1.Services.Movie
{
    public interface IMovieService
    {
        Model.Movie GetById(int id);
        List<Model.Movie> GetAll();
    }
}
