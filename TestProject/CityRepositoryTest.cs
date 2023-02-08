using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository.City;
using WebApplication1.Repository.State;

namespace TestProject
{
   public  class CityRepositoryTest
    {
        [Fact]
        public void GetCitiesWhereIsOnlyOneValueExitsTest()
        {
            // Arrange
            var cities = new List<City>()
            {
                new City
                {
                    CityId= 1,
                    CityName= "jabalpur",
                    StateId= 1,
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me"
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<City>>();

            context.Setup(x => x.Set<City>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(cities.AsQueryable());

            // Act
            var repository = new CityRepository(context.Object);
            var getCities = repository.GetAll();

            // Assert
            Assert.Equal(1, getCities.Count);
        }

        [Fact]
        public void GetAllCitiesTest()
        {
            // Arrange
            var cities = new List<City>()
            {
                new City
                {
                       CityId= 1,
                    CityName= "jabalpur",
                    StateId= 1,
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me"
                },
                 new City
                {
                    CityId= 2,
                    CityName= "katni",
                    StateId= 2,
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me"
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<City>>();

            context.Setup(x => x.Set<City>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(cities.AsQueryable());

            // Act
            var repository = new CityRepository(context.Object);
            var getCities = repository.GetAll();

            // Assert
            Assert.Equal(cities, getCities.ToList());
        }

        [Fact]
        public void GetCityByIdTest()
        {
            // Arrange
            var city = 
                new City
                {
                    CityId = 1,
                    CityName = "jabalpur",
                    StateId = 1,
                    IsActive = true,
                    CreatedBy = "me",
                    UpdatedBy = "me"
                };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<City>>();

            context.Setup(x => x.Set<City>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(city);


            // Act
            var repository = new CityRepository(context.Object);
            var getCities = repository.GetById(1);

            // Assert
            Assert.Equal(city, getCities);
        }
    }
}
