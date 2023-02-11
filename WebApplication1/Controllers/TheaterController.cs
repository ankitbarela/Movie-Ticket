using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Screen;
using WebApplication1.Services.Theater;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterService theaterService;
        private readonly IMapper mapper;
        public TheaterController(ITheaterService theaterService, IMapper mapper)
        {
            this.theaterService = theaterService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<TheaterViewModel> Get()
        {
            var theaters = theaterService.GetAll();
            var theaterView = mapper.Map<List<TheaterViewModel>>(theaters);
            return theaterView;
        }

        [HttpGet("{id}")]
        public TheaterViewModel Get(int id)
        {
            var theater = theaterService.GetById(id);
            var theaterView = mapper.Map<TheaterViewModel>(theater);
            return theaterView;
        }
    }
}
