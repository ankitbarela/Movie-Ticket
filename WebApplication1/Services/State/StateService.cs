using WebApplication1.Repository.State;

namespace WebApplication1.Services.State
{
    public class StateService : IStateService
    {
        private readonly IStateRepository stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }
        public List<Model.State> GetAll()
        {
            var states = stateRepository.GetAll();
            return states;
        }

        public Model.State GetById(int id)
        {
            var state = stateRepository.GetById(id);    
            return state;
        }
    }
}
