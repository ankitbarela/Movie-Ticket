using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.City;
using WebApplication1.Services.City;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ICityService cityService;
        private readonly IMapper mapper;

        public CityController(ICityService cityService , IMapper mapper)
        {
            this.cityService = cityService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CityViewModel> Get()
        {
            var cityies = cityService.GetAll();
            var citiesView = mapper.Map<List<CityViewModel>>(cityies);  
            return citiesView;
        }

        [HttpGet("{id}")]
        public CityViewModel Get(int id)
        {
            var city = cityService.GetById(id);
            var cityView = mapper.Map<CityViewModel>(city);
            return cityView;
        }

    }
}
