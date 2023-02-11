using WebApplication1.Repository.Screen;

namespace WebApplication1.Services.Screen
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository screenRepository;

        public ScreenService(IScreenRepository screenRepository)
        {
            this.screenRepository = screenRepository;
        }
        public List<Model.Screen> GetAll()
        {
            var screens = screenRepository.GetAll();
            return screens;
        }

        public Model.Screen GetById(int id)
        {
            var screen = screenRepository.GetById(id);  
            return screen;
        }
    }
}
