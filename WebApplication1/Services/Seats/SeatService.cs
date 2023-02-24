using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;
using WebApplication1.Repository.Seat;

namespace WebApplication1.Services.Seat
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }

        public List<Model.Seat> GetAll()
        {
          var allSeats = seatRepository.GetAll();
          return allSeats;
        }

        public Model.Seat GetById(int id)
        {
            var seat = new Model.Seat();
            return seat;
        }
    }
}
