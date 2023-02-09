using WebApplication1.Repository.City;
using WebApplication1.Repository.Movie;

namespace WebApplication1.Services.Movie
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public List<Model.Movie> GetAll()
        {
            var movies = movieRepository.GetAll();
            return movies;
        }

        public Model.Movie GetById(int id)
        {
            var movie = movieRepository.GetById(id);
            return movie;
        }
    }
}
