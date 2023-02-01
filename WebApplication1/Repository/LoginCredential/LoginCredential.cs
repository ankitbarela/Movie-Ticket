﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;
using WebApplication1.Model;

namespace WebApplication1.Repository.LoginCredential
{
    public class LoginCredential : ILoginCredential
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.LoginCredential> entities;
        public LoginCredential(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.LoginCredential>();
        }
        public Model.LoginCredential Create(Model.LoginCredential loginCredential)
        {
            this.dbContext.Add(loginCredential);
            this.dbContext.SaveChanges();
            return loginCredential;
        }

        public List<Model.LoginCredential> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.LoginCredential GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
