using Moq;
using PointOfInterestByGpsUnitTests.Builders;
using PointsOfInterestByGps.Controllers;
using PointsOfInterestByGps.Models;
using PointsOfInterestByGps.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace PointOfInterestByGpsUnitTests.Controllers
{
    public class PointsOfInterestControllerTests
    {
        private readonly Mock<IPoinsLocaleCoordinateRepository> _repositoryMock;
        private readonly PointsLocaleCoordinatesModelBuilder _modelBuilder;
        private readonly PointsOfInterestController _sut;

        public PointsOfInterestControllerTests()
        {
            _repositoryMock = new ();
            _modelBuilder = new ();
            _sut = new (_repositoryMock.Object);
        }

        [Fact]
        public void ShouldGetAllPoints()
        {
            List<PointsLocaleCoordinatesModel> modelList = new()
            {
                _modelBuilder.CreateObject(),
                _modelBuilder.CreateObject(),
                _modelBuilder.CreateObject()
            };

            _repositoryMock.Setup(x => x.GetAllPoints()).Returns(modelList);

           var result = _sut.GetAllPoints();

            _repositoryMock.Verify(x => x.GetAllPoints(), Times.Once());
            
        }
    }
}
