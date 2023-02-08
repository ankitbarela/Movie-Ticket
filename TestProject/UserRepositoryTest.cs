using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using WebApplication1;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository.State;
using WebApplication1.Repository.User;
using Xunit.Sdk;

namespace TestProject
{
    public class UserRepositoryTest
    {

        [Fact]
        public void GetUsersWhereIsOnlyOneValueExitsTest()
        {
            // Arrange
            var users = new List<User>()
            {
                new User
                {
                    UserId= 1,
                    Name= "ankit",
                    Email= "test@gmail.com",
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me",
                    Password="dsjfns",
                    Age=23,
                    ContactNumber="343224",
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<User>>();

            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i=> i.AsQueryable()).Returns(users.AsQueryable());

            // Act
            var repository = new UserRepository(context.Object);
            var getUsers =  repository.GetAll();

            // Assert
            Assert.Equal(1, getUsers.Count);
        }

        [Fact]
        public void GetAllUsersTest()
        {
            // Arrange
            var users = new List<User>()
            {
                new User
                {
                      UserId= 1,
                    Name= "ankit",
                    Email= "test@gmail.com",
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me",
                    Password="dsjfns",
                    Age=23,
                    ContactNumber="343224",
                },
                 new User
                {
                    UserId= 2,
                    Name= "ankit",
                    Email= "test@gmail.com",
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me",
                    Password="dsjfns",
                    Age=23,
                    ContactNumber="343224",
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<User>>();

            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(users.AsQueryable());

            // Act
            var repository = new UserRepository(context.Object);
            var getUsers = repository.GetAll();

            // Assert
            Assert.Equal(users, getUsers.ToList());
        }

        [Fact]
        public void GetStateByIdTest()
        {
            // Arrange
            var user =
                  new User
                  {
                      UserId = 2,
                      Name = "ankit",
                      Email = "test@gmail.com",
                      IsActive = true,
                      CreatedBy = "me",
                      UpdatedBy = "me",
                      Password = "dsjfns",
                      Age = 23,
                      ContactNumber = "343224",
                  };


            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<User>>();

            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(user);
            // Act
            var repository = new UserRepository(context.Object);
            var gateUser = repository.GetById(1);

            // Assert
            Assert.Equal(user, gateUser);
        }
    }
}