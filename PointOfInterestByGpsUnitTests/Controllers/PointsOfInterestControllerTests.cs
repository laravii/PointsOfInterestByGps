using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PointOfInterestByGpsUnitTests.Builders;
using PointsOfInterestByGps.Controllers;
using PointsOfInterestByGps.Models;
using PointsOfInterestByGps.Repositories;
using PointsOfInterestByGps.Requests;
using PointsOfInterestByGps.Validations;

namespace PointOfInterestByGpsUnitTests.Controllers
{
    public class PointsOfInterestControllerTests
    {
        private readonly Mock<IPoinsLocaleCoordinateRepository> _repositoryMock;
        private readonly Mock<IValidator<PointsLocaleCordinateRequest>> _validatorMock;
        private readonly PointsLocaleCoordinatesModelBuilder _modelBuilder;
        private readonly PointsLocaleCordinateRequestBuilder _requestBuilder;
        private readonly PointsOfInterestController _sut;

        public PointsOfInterestControllerTests()
        {
            _repositoryMock = new();
            _validatorMock = new();
            _modelBuilder = new();
            _requestBuilder = new();
            _sut = new(_repositoryMock.Object, _validatorMock.Object);
        }

        [Fact]
        public void Should_Get_All_Points()
        {
            List<PointsLocaleCoordinatesModel> modelList = new()
            {
                _modelBuilder.Build(),
                _modelBuilder.Build(),
                _modelBuilder.Build()
            };
            _repositoryMock.Setup(x => x.GetAllPoints()).Returns(modelList);

            var result = _sut.GetAllPoints().Result as OkObjectResult;
            var items = Assert.IsType<List<PointsLocaleCoordinatesModel>>(result?.Value);

            Assert.Equal(3, items.Count);
            _repositoryMock.Verify(x => x.GetAllPoints(), Times.Once());
        }

        [Fact]
        public void Should_Find_Near_Points()
        {
            List<PointsLocaleCoordinatesModel> modelList = new()
            {
                _modelBuilder.Description("Lanchonete").Coordinates(10, 20).Build(),
                _modelBuilder.Description("Mercado").Coordinates(12, 18).Build(),
                _modelBuilder.Description("Restaurante").Coordinates(40, 52).Build()
            };
            _repositoryMock.Setup(x => x.GetAllPoints()).Returns(modelList);

            var result = _sut.GetNearPoints(13, 17, 10).Result as OkObjectResult;
            var items = Assert.IsType<List<PointsLocaleCoordinatesModel>>(result?.Value);

            Assert.Equal(2, items.Count);
            _repositoryMock.Verify(x => x.GetAllPoints(), Times.Once());
        }


        [Fact]
        public void Should_Create_New_Point()
        {
            PointsLocaleCordinateRequest request = _requestBuilder.Build();
            PointsLocaleCoordinatesModel model = _modelBuilder
                .Description(request.PointDescription)
                .Coordinates(request.CoordinateX, request.CoordinateY)
                .Build();
            _validatorMock.Setup(x => x.Validate(request)).Returns(new ValidationResult());


            _repositoryMock.Setup(x => x.Create(It.IsAny<PointsLocaleCoordinatesModel>())).Returns(model);

            var result = _sut.CreateNewPoint(request).Result as OkObjectResult;
            var item = Assert.IsType<PointsLocaleCoordinatesModel>(result?.Value);

            Assert.True(item != null);
            _repositoryMock.Verify(x => x.Create(It.IsAny<PointsLocaleCoordinatesModel>()), Times.Once());
        }


        [Fact]
        public void Should_BadRequest_When_Valitation_Fail_To_CreateNewPoint()
        {
            PointsLocaleCordinateRequest request = _requestBuilder.Build();

            var validationError = new ValidationFailure();
            _validatorMock.Setup(x => x.Validate(request)).Returns(
                new ValidationResult(
                    new List<ValidationFailure>() { validationError }));

            var result = _sut.CreateNewPoint(request).Result as BadRequestObjectResult;

            _repositoryMock.Verify(x => x.Create(It.IsAny<PointsLocaleCoordinatesModel>()), Times.Never());
        }
    }
}
