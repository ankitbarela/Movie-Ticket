using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using WebApplication1;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository.LoginCredential;
using WebApplication1.Repository.State;
using Xunit.Sdk;

namespace TestProject
{
    public class LoginCredentialRepositoryTest
    {

        [Fact]
        public void GetLoginWhereIsOnlyOneValueExitsTest()
        {
            // Arrange
            var loginCredentials = new List<LoginCredential>()
            {
                new LoginCredential
                {
                    CredentialId= 1,
                    UserId= 1,
                    UserName= "Test",
                    IsActive= true,
                    CreatedBy=1,
                    UpdatedBy =1,
                    Password= "Test@123",
                    Email="test@gmail.com"
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<LoginCredential>>();

            context.Setup(x => x.Set<LoginCredential>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i=> i.AsQueryable()).Returns(loginCredentials.AsQueryable());

            // Act
            var repository = new LoginCredentialRepository(context.Object);
            var getStates =  repository.GetAll();

            // Assert
            Assert.Equal(1, getStates.Count);
        }

        //[Fact]
        //public void CreateLoginCredentialTest()
        //{
        //    // Arrange
        //    var loginCredential = new LoginCredential();

        //    var context = new Mock<MovieContext>();
        //    var dbSetMock = new Mock<DbSet<LoginCredential>>();

        //    context.Setup(x => x.Set<LoginCredential>()).Returns(dbSetMock.Object);
        //    dbSetMock.Setup(x => x.Add(It.IsAny<LoginCredential>())).Returns();


        //    // Act
        //    var repository = new LoginCredentialRepository(context.Object);
        //    repository.Create(loginCredential);

        //    // Assert
        //    context.Verify(x => x.Set<LoginCredential>());
        //}

        [Fact]
        public void GetAllStatesTest()
        {
            // Arrange
            var loginCredentials = new List<LoginCredential>()
            {
                new LoginCredential
                {
                    CredentialId= 1,
                    UserId= 1,
                    UserName= "Test",
                    IsActive= true,
                    CreatedBy=1,
                    UpdatedBy =1,
                    Password= "Test@123",
                    Email="test@gmail.com"
                },
                 new LoginCredential
                {
                    CredentialId= 2,
                    UserId= 2,
                    UserName= "Test1",
                    IsActive= true,
                    CreatedBy=1,
                    UpdatedBy =1,
                    Password= "Test@123",
                    Email="test@gmail.com"
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<LoginCredential>>();

            context.Setup(x => x.Set<LoginCredential>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(loginCredentials.AsQueryable());

            // Act
            var repository = new LoginCredentialRepository(context.Object);
            var getLoginCredentials = repository.GetAll();

            // Assert
            Assert.Equal(loginCredentials, getLoginCredentials.ToList());
        }

        [Fact]
        public void GetStateByIdTest()
        {
            // Arrange
            var loginCredential =
                new LoginCredential
                {
                    CredentialId = 1,
                    UserId = 1,
                    UserName = "Test",
                    IsActive = true,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    Password = "Test@123",
                    Email = "test@gmail.com"
                };


            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<LoginCredential>>();

            context.Setup(x => x.Set<LoginCredential>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(loginCredential);
            // Act
            var repository = new LoginCredentialRepository(context.Object);
            var gateState = repository.GetById(1);

            // Assert
            Assert.Equal(loginCredential, gateState);
        }
    }
}