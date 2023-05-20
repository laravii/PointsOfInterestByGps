using Moq;
using PointOfInterestByGpsUnitTests.Builders;
using PointsOfInterestByGps.Contexts;
using PointsOfInterestByGps.Models;
using PointsOfInterestByGps.Repositories;

namespace PointOfInterestByGpsUnitTests.Infrastructure
{
    public class PoinsLocaleCoordinateRepositoryTests
    {
        private PoinsLocaleCoordinateRepository _sut;
        private readonly Mock<PointLocaleCoordinateContext> _contextMock;
        private readonly PointsLocaleCoordinatesModelBuilder _modelBuilder;

        public PoinsLocaleCoordinateRepositoryTests()
        {
            _contextMock = new();
            _modelBuilder = new();
            _sut = new(_contextMock.Object);
        }

        [Fact]
        public void ShouldCreate()
        {
            PointsLocaleCoordinatesModel model = _modelBuilder.Build();

            var result = _sut.Create(model);

            // Assert
            _contextMock.Verify(c => c.Add(model), Times.Once);
            _contextMock.Verify(c => c.SaveChanges(), Times.Once);
            Assert.Equal(model, result);
        }
    }
}
