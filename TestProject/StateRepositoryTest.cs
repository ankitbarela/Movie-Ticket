using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using WebApplication1;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository.State;
using Xunit.Sdk;

namespace TestProject
{
    public class StateRepositoryTest 
    {

        [Fact]
        public void GetStatesTest()
        {
            // Arrange
            var states = new List<State>()
            {
                new State
                {
                    StateCode= 1,
                    StateId= 1,
                    StateName= "Test",
                    IsActive= true,
                    Createdby="me",
                    Updatedby ="me"
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<State>>();

            context.Setup(x => x.Set<State>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i=> i.AsQueryable()).Returns(states.AsQueryable());

            // Act
            var repository = new StateRepository(context.Object);
            var getStates =  repository.GetAll();

            // Assert
            Assert.Equal(1, getStates.Count);
        }

        [Fact]
        public void GetStateByIdTest()
        {
            // Arrange
            var state =
                new State
                {
                    StateCode = 1,
                    StateId = 1,
                    StateName = "Test",
                    IsActive = true,
                    Createdby = "me",
                    Updatedby = "me"
                };
           
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<State>>();

            context.Setup(x => x.Set<State>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(state);
            // Act
            var repository = new StateRepository(context.Object);
            var gateState = repository.GetById(1);

            // Assert
            Assert.Equal(1, gateState.StateId);
        }
    }
}