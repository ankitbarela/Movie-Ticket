using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository.LoginCredential;
using WebApplication1.Repository.Movie;
using WebApplication1.Repository.User;
using WebApplication1.Services.User;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ILoginCredentialRepository loginCredential;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;
        IMapper mapper;

        public UserController(IUserRepository userRepository, ILoginCredentialRepository loginCredential, ILogger<UserController> logger,IUserService userService, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.loginCredential = loginCredential;
            _logger = logger;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            _logger.LogInformation("user executing");
            var users = userService.GetAll();
            var userViewModels = mapper.Map<List<UserViewModel>>(users);
          //  var users = userRepository.GetAll();
            return userViewModels;
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
        public IResult Post(User user)
        {
            var encryptedPassword = userRepository.EncodePassword(user.Password);
            user.Password = encryptedPassword;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.IsActive= true;
            var userCreated = userRepository.Create(user);
            if (userCreated != null)
            {
                return Results.Ok(user.Email);
            }
            return Results.BadRequest();    
        }

        [HttpPut]
        [AllowAnonymous]
        [Produces("application/json")]
        public IResult Update(string email , string password)
        {
            var passwordChangedUser = userRepository.GetByEmail(email);
            var convertUsertoLogin = loginCredential.AddData(passwordChangedUser);
            loginCredential.Create(convertUsertoLogin);
            var encryptedPassword = userRepository.EncodePassword(password);
            passwordChangedUser.Password = encryptedPassword;
            var loginCredentials = loginCredential.GetByEmail(email);
            for (int i = 0; i < 3; i++)
            {
                var lastThreeElements = loginCredentials.LastOrDefault();
                if (lastThreeElements != null)
                {
                    if (lastThreeElements.Password == encryptedPassword)
                    {
                        return Results.BadRequest();
                    }
                    loginCredentials.RemoveAt(loginCredentials.Count - 1);
                }
            }
            var userCreated = userRepository.Update(passwordChangedUser);
            if (userCreated != null)
            {
                return Results.Ok(passwordChangedUser.Email);
            }
            return Results.BadRequest();
        }
    }
}
