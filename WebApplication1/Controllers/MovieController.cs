using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.Movie;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public IEnumerable<Model.Movie> Get()
        {
            var movies = movieRepository.GetAll();
            return movies;
        }

        [HttpGet("{id}")]
        public List<Model.Movie> Get(int id)
        {
            var moviesById = new List<Model.Movie>();
            var movies = movieRepository.GetAll();
            foreach (var movie in movies)
            {
                if (movie.CityId == id)
                {
                    moviesById.Add(movie);
                }
            }
            return moviesById;
        }
    }
}
