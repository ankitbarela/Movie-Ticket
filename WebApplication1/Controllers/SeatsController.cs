using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.Seat;
using WebApplication1.Services.Screen;
using WebApplication1.Services.Seat;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService seatService;
        private readonly IMapper mapper;
        public SeatsController(ISeatService seatService, IMapper mapper)
        {
            this.seatService = seatService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<SeatViewModel> Get()
        {
            var seats = seatService.GetAll();
            var seatView = mapper.Map<List<SeatViewModel>>(seats);
            return seatView;
        }

        [HttpGet("{id}")]
        public SeatViewModel Get(int id)
        {
            var seat = seatService.GetById(id);
            var seatView = mapper.Map<SeatViewModel>(seat);
            return seatView;
        }
    }
}
