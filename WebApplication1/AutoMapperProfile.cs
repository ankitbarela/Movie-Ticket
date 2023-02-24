using AutoMapper;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User , UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<UserViewModel, User>();
            CreateMap<State, StateViewModel>();
            CreateMap<City, CityViewModel>();
            CreateMap<Movie, MovieViewModel>();
            CreateMap<LoginCredential, LoginCredentialViewModel>();
            CreateMap<LoginCredentialViewModel, LoginCredential>();
            CreateMap<ScreenViewModel, Screen>();
            CreateMap<Screen, ScreenViewModel>();
            CreateMap<TheaterViewModel, Theater>().ReverseMap();
            CreateMap<SeatViewModel, Seat>().ReverseMap();
            CreateMap<ShowViewModel, Show>().ReverseMap();
            CreateMap<BookingSummary, BookingSummaryViewModel>();
            CreateMap<BookingSummaryViewModel, BookingSummary>();
            CreateMap<BookedSeatsViewModel, BookedSeats>();
            CreateMap<BookedSeats, BookedSeatsViewModel>();
        }
    }
}
