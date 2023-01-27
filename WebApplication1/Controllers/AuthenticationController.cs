using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public AuthenticationController(ISecurityService securityService)
        {
            _securityService = securityService;
        }
        [HttpPost("/signin")]
        [AllowAnonymous]
        [Produces("application/json")]
        public async Task<IResult> SignIn(LoginRequest request)
        {
            bool isValid = false;
            string token;
           (isValid, token) =_securityService.ValidateUser(request) ;
           return isValid? Results.Ok(token): Results.Unauthorized();

        } 
    }
}
