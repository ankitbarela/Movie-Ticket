using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services.BookedSeat;
using WebApplication1.Services.BookingSummary;
using WebApplication1.Services.User;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingSummaryController : ControllerBase
    {
        private readonly IBookingSummaryService bookingSummaryService;
        private readonly IMapper mapper;
        private readonly IBookedSeatService bookedSeatService;

        public BookingSummaryController(IBookingSummaryService bookingSummaryService, IMapper mapper , IBookedSeatService bookedSeatService)
        {
            this.bookingSummaryService = bookingSummaryService;
            this.mapper = mapper;
            this.bookedSeatService = bookedSeatService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        public async Task<IResult> Post(BookingSummaryViewModel bookingSummaryViewModel)
        {
            try
            {
                var bookingSummaryMap = mapper.Map<BookingSummary>(bookingSummaryViewModel);
                var bookinSummary = bookingSummaryService.Create(bookingSummaryMap);
                bookedSeatService.Create(bookingSummaryViewModel.BookedSeats, bookingSummaryViewModel.ShowId);
                if (bookinSummary != null)
                {
                    return Results.Ok(bookingSummaryViewModel.MovieName);
                }
                return Results.BadRequest();
            }
            catch (Exception e)
            {
                throw;
            }
           
        }
    }
}
