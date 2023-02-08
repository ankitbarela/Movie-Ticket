using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository.LoginCredential;
using WebApplication1.Repository.Movie;
using WebApplication1.Repository.User;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginCredentialController : ControllerBase
    {
        private readonly ILoginCredentialRepository _loginCredential;
        private readonly IUserRepository userRepository;

        public LoginCredentialController(ILoginCredentialRepository loginCredential, IUserRepository userRepository)
        {
            this._loginCredential = loginCredential;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<Model.LoginCredential> Get()
        {
            var loginCredentials = _loginCredential.GetAll();
            return loginCredentials;
        }

        [HttpGet("{id}")]
        public Model.LoginCredential Get(int id)
        {
            var logCredential = _loginCredential.GetById(id);
            return logCredential;
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        public IResult Post(Model.LoginCredential loginCredential)
        {
            var encryptedPassword = userRepository.EncodePassword(loginCredential.Password);
            loginCredential.Password = encryptedPassword;
            loginCredential.CreatedAt = DateTime.Now;
            loginCredential.UpdatedAt = DateTime.Now;
            var LoginCredentialCreated = _loginCredential.Create(loginCredential);
            if (LoginCredentialCreated != null)
            {
                return Results.Ok(loginCredential.Email);
            }
            return Results.BadRequest();    
        }

    }
}
