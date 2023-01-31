using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Model;
using WebApplication1.Repository.User;

namespace WebApplication1.Services
{

    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public SecurityService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public (bool, string) ValidateUser(LoginRequest loginDetails)
        {
            var encryptPassword = _userRepository.EncodePassword(loginDetails.Password);
            loginDetails.Password = encryptPassword;
            var user = _userRepository.Authenticate(loginDetails.UserName, loginDetails.Password);
            if (user != null)
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                    (_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, loginDetails.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, loginDetails.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return (true, stringToken);
            }
            return (false, "");
        }
    }
}
