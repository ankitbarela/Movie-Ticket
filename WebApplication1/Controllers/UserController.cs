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
        private readonly ILoginCredentialRepository loginCredential;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;
        IMapper mapper;

        public UserController(ILoginCredentialRepository loginCredential, ILogger<UserController> logger,IUserService userService, IMapper mapper)
        {
            this.loginCredential = loginCredential;
            _logger = logger;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> Get()
        {
            _logger.LogInformation("user executing");
            var users = userService.GetAll();
            var userViewModels = mapper.Map<List<UserViewModel>>(users);
            return userViewModels;
        }

        [HttpGet("{id}")]
        public UserViewModel Get(int id)
        {
            var user = userService.GetById(id);
            var userView = mapper.Map<UserViewModel>(user);
            return userView;
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        public IResult Post(UserViewModel userViewModel)
        {
            var encryptedPassword = userService.EncodePassword(userViewModel.Password);
            userViewModel.Password = encryptedPassword;
            var user = mapper.Map<User>(userViewModel);
            var userCreated = userService.Create(user);
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
            var passwordChangedUser = userService.GetByEmail(email);
            var convertUsertoLogin = loginCredential.AddData(passwordChangedUser);
            loginCredential.Create(convertUsertoLogin);
            var encryptedPassword = userService.EncodePassword(password);
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
            var userCreated = userService.Update(passwordChangedUser);
            if (userCreated != null)
            {
                return Results.Ok(passwordChangedUser.Email);
            }
            return Results.BadRequest();
        }
    }
}
