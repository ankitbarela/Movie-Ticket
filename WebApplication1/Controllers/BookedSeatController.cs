using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApplication1.Model;
using WebApplication1.Services.BookedSeat;
using WebApplication1.Services.City;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedSeatController : ControllerBase
    {
        private readonly IBookedSeatService bookedSeatService;
        private readonly IMapper mapper;

        public BookedSeatController(IBookedSeatService bookedSeatService, IMapper mapper)
        {
            this.bookedSeatService = bookedSeatService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookedSeatsViewModel>> Get()
        {
            var seats = bookedSeatService.GetAll();
            var seatView = mapper.Map<List<BookedSeatsViewModel>>(seats);
            return seatView;
        }
    }
}
