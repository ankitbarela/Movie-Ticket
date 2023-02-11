using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Seat;
using WebApplication1.Services.Show;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IShowService showService;
        private readonly IMapper mapper;
        public ShowsController(IShowService showService, IMapper mapper)
        {
            this.showService = showService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ShowViewModel> Get()
        {
            var seats = showService.GetAll();
            var seatView = mapper.Map<List<ShowViewModel>>(seats);
            return seatView;
        }

        [HttpGet("{id}")]
        public ShowViewModel Get(int id)
        {
            var show = showService.GetById(id);
            var showView = mapper.Map<ShowViewModel>(show);
            return showView;
        }
    }
}
