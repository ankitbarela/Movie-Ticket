using WebApplication1.Repository.BookingSummary;

namespace WebApplication1.Services.BookingSummary
{
    public class BookingSummaryService : IBookingSummaryService
    {
        private readonly IBookingSummaryRepository bookingSummaryRepository;

        public BookingSummaryService(IBookingSummaryRepository bookingSummaryRepository)
        {
            this.bookingSummaryRepository = bookingSummaryRepository;
        }
        public Model.BookingSummary Create(Model.BookingSummary bookingSummary)
        {
            bookingSummary.IsActive= true;
            bookingSummary.CreatedBy = 1;
            bookingSummary.UpdatedBy= 1;
            bookingSummary.CreatedAt= DateTime.Now; 
            bookingSummary.UpdatedAt= DateTime.Now; 
            var booking = bookingSummaryRepository.Create(bookingSummary);
            return booking;
        }
    }
}
