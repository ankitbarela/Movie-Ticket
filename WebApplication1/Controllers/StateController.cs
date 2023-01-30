using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.State;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        [HttpGet]
        public IEnumerable<Model.State> Get()
        {
            var states = stateRepository.GetAll();
            return states;
        }

        [HttpGet("{id}")]
        public Model.State Get(int id)
        {
            var state = stateRepository.GetById(id);
            return state;
        }
    }
}
