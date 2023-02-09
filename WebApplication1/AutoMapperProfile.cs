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
        }
    }
}
