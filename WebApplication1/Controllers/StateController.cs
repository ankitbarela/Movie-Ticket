using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.State;
using WebApplication1.Services.State;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService stateService;
        private readonly IMapper mapper;

        public StateController(IStateService stateService , IMapper mapper)
        {
            this.stateService = stateService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StateViewModel> Get()
        {
            var states = stateService.GetAll();
            var statesView = mapper.Map<List<StateViewModel>>(states);
            return statesView;
        }

        [HttpGet("{id}")]
        public StateViewModel Get(int id)
        {
            var state = stateService.GetById(id);
            var stateView = mapper.Map<StateViewModel>(state);  
            return stateView;
        }
    }
}
