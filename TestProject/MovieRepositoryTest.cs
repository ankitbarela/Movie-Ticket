using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using WebApplication1;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository.Movie;
using WebApplication1.Repository.State;
using Xunit.Sdk;

namespace TestProject
{
    public class MovieRepositoryTest
    {

        [Fact]
        public void GetMoviesWhereIsOnlyOneValueExitsTest()
        {
            // Arrange
            var movies = new List<Movie>()
            {
                new Movie
                {
                    MovieId= 1,
                    CityId= 1,
                    MovieName= "Test1",
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me",
                    ImageName="avtar",
                    ProducerName="sijndf",
                    CastingPartner="dsjfn"
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<Movie>>();

            context.Setup(x => x.Set<Movie>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i=> i.AsQueryable()).Returns(movies.AsQueryable());

            // Act
            var repository = new MovieRepository(context.Object);
            var getMovies =  repository.GetAll();

            // Assert
            Assert.Equal(1, getMovies.Count);
        }

        [Fact]
        public void GetAllMoviesTest()
        {
            // Arrange
            var movies = new List<Movie>()
            {
                new Movie
                {
                    MovieId= 1,
                    CityId= 1,
                    MovieName= "Test1",
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me",
                    ImageName="avtar",
                    ProducerName="sijndf",
                    CastingPartner="dsjfn"
                },
                new Movie
                {
                    MovieId= 2,
                    CityId= 2,
                    MovieName= "Test2",
                    IsActive= true,
                    CreatedBy="me",
                    UpdatedBy ="me",
                    ImageName="kgf",
                    ProducerName="sijndf",
                    CastingPartner="dsjfn"
                }
            };
            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<Movie>>();

            context.Setup(x => x.Set<Movie>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(movies.AsQueryable());

            // Act
            var repository = new MovieRepository(context.Object);
            var getMovies = repository.GetAll();

            // Assert
            Assert.Equal(movies, getMovies.ToList());
        }

        [Fact]
        public void GetMovieByIdTest()
        {
            // Arrange
            var movie =
                new Movie
                {
                    MovieId = 1,
                    CityId = 1,
                    MovieName = "Test1",
                    IsActive = true,
                    CreatedBy = "me",
                    UpdatedBy = "me",
                    ImageName = "avtar",
                    ProducerName = "sijndf",
                    CastingPartner = "dsjfn"
                };

            var context = new Mock<MovieContext>();
            var dbSetMock = new Mock<DbSet<Movie>>();

            context.Setup(x => x.Set<Movie>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(movie);
            // Act
            var repository = new MovieRepository(context.Object);
            var gateMovie = repository.GetById(1);

            // Assert
            Assert.Equal(movie, gateMovie);
        }
    }
}