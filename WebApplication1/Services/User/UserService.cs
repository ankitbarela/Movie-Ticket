using WebApplication1.Repository.User;

namespace WebApplication1.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
        public Model.User Authenticate(string userName, string password)
        {
            var authenticateUser = _userRepository.Authenticate(userName, password);   
            return authenticateUser;
        }

        public Model.User Create(Model.User user)
        {
            user.CreatedBy = "me";
            user.UpdatedBy = "me";
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.IsActive = true;
            var createUser = _userRepository.Create(user);
            return createUser;
        }

        public string EncodePassword(string password)
        {
           var encodedPassword = _userRepository.EncodePassword(password);
           return encodedPassword;
        }

        public List<Model.User> GetAll()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public Model.User GetByEmail(string email)
        {
           var userByEmail = _userRepository.GetByEmail(email);
           return userByEmail;
        }

        public Model.User GetById(int id)
        {
            var userById = _userRepository.GetById(id); 
            return userById;
        }

        public Model.User Update(Model.User user)
        {
           var updateUser = _userRepository.Update(user);
            return updateUser;
        }
    }
}
