using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.City;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ICityRepository cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public IEnumerable<Model.City> Get()
        {
            var cityies = cityRepository.GetAll();
            return cityies;
        }

        [HttpGet("{id}")]
        public Model.City Get(int id)
        {
            var city = cityRepository.GetById(id);
            return city;
        }

    }
}
