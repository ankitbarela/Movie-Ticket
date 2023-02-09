using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.Movie;
using WebApplication1.Services.Movie;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;


        public MovieController(IMovieService movieService , IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<MovieViewModel> Get()
        {
            var movies = movieService.GetAll();
            var moviesView =  mapper.Map<List<MovieViewModel>>(movies);
            return moviesView;
        }

        [HttpGet("{id}")]
        public List<MovieViewModel> Get(int id)
        {
            var moviesById = new List<MovieViewModel>();
            var movies = movieService.GetAll();
            var moviesView= mapper.Map<List<MovieViewModel>>(movies);
            foreach (var movie in moviesView)
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
