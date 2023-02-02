﻿using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ILoginCredential loginCredential;

        public UserController(IUserRepository userRepository , ILoginCredential loginCredential)
        {
            this.userRepository = userRepository;
            this.loginCredential = loginCredential;
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
        public IResult Post(User user)
        {
            var encryptedPassword = userRepository.EncodePassword(user.Password);
            user.Password = encryptedPassword;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
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
                if (lastThreeElements.Password == encryptedPassword)
                {
                    return Results.BadRequest();
                }
                loginCredentials.RemoveAt(loginCredentials.Count - 1);
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
