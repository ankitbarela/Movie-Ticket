using WebApplication1.Repository.City;

namespace WebApplication1.Services.City
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public List<Model.City> GetAll()
        {
            var cities = cityRepository.GetAll();
            return cities;
        }

        public Model.City GetById(int id)
        {
            var city = cityRepository.GetById(id);
            return city;
        }
    }
}
