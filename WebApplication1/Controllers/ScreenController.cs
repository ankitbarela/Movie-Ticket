using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services.LoginCredential;
using WebApplication1.Services.Screen;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        private readonly IScreenService screenService;
        private readonly IMapper mapper;
        public ScreenController(IScreenService screenService, IMapper mapper)
        {
            this.screenService = screenService;
            this.mapper = mapper;   
        }
        [HttpGet]
        public IEnumerable<ScreenViewModel> Get()
        {
            var screens = screenService.GetAll();
            var screenView = mapper.Map<List<ScreenViewModel>>(screens);
            return screenView;
        }

        [HttpGet("{id}")]
        public ScreenViewModel Get(int id)
        {
            var screen = screenService.GetById(id);
            var screenView = mapper.Map<ScreenViewModel>(screen);
            return screenView;
        }

    }
}
