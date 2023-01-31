using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository.Movie;
using WebApplication1.Repository.User;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = userRepository.GetAll();
            return users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = userRepository.GetById(id);
            return user;
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        public async void Post(User user)
        {
            var encryptedPassword = userRepository.EncodePassword(user.Password);
            user.Password = encryptedPassword;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            userRepository.Create(user);
        }

    }
}
