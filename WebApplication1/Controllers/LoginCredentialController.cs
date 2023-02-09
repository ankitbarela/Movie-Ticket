using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository.LoginCredential;
using WebApplication1.Repository.Movie;
using WebApplication1.Repository.User;
using WebApplication1.Services.LoginCredential;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginCredentialController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ILoginCredentialService loginCredentialService;
        private readonly IMapper mapper;

        public LoginCredentialController(IUserRepository userRepository, ILoginCredentialService loginCredentialService , IMapper mapper)
        {
            this.userRepository = userRepository;
            this.loginCredentialService = loginCredentialService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<LoginCredentialViewModel> Get()
        {
            var loginCredentials = loginCredentialService.GetAll();
            var loginCredentialsView = mapper.Map<List<LoginCredentialViewModel>>(loginCredentials);
            return loginCredentialsView;
        }

        [HttpGet("{id}")]
        public LoginCredentialViewModel Get(int id)
        {
            var logCredential = loginCredentialService.GetById(id);
            var loginCredentialView = mapper.Map<LoginCredentialViewModel>(logCredential);
            return loginCredentialView;
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        public IResult Post(LoginCredentialViewModel loginCredentialView)
        {
            var encryptedPassword = userRepository.EncodePassword(loginCredentialView.Password);
            loginCredentialView.Password = encryptedPassword;
            var loginCrdential = mapper.Map<LoginCredential>(loginCredentialView);    
            var LoginCredentialCreated = loginCredentialService.Create(loginCrdential);
            if (LoginCredentialCreated != null)
            {
                return Results.Ok(loginCredentialView.Email);
            }
            return Results.BadRequest();    
        }

    }
}
