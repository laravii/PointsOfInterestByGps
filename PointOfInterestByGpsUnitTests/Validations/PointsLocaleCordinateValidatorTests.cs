using FluentValidation.TestHelper;
using PointOfInterestByGpsUnitTests.Builders;
using PointsOfInterestByGps.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfInterestByGpsUnitTests.Validations
{
    public class PointsLocaleCordinateValidatorTests
    {
        private readonly PointsLocaleCordinateValidator _sut;
        private readonly PointsLocaleCordinateRequestBuilder _requestBuilder;

        public PointsLocaleCordinateValidatorTests()
        {
            _sut = new();
            _requestBuilder = new();
        }

        [Fact]
        public void Should_have_error_when_description_is_Empty()
        {
            var request = _requestBuilder.Description("").Build();
            var result = _sut.TestValidate(request);
            result.ShouldHaveValidationErrorFor(p => p.PointDescription);
        }

        [Fact]
        public void Should_not_have_error_when_name_is_specified()
        {
            var request = _requestBuilder.Build();
            var result = _sut.TestValidate(request);
            result.ShouldNotHaveValidationErrorFor(p => p.PointDescription);
        }

        [Fact]
        public void Should_have_error_when_coordinateY_is_negative()
        {
            var request = _requestBuilder.CoordinateY(-5).Build();
            var result = _sut.TestValidate(request);
            result.ShouldHaveValidationErrorFor(p => p.CoordinateY);
        }

        [Fact]
        public void Should_not_have_error_when_coordinateY_is_positive()
        {
            var request = _requestBuilder.Build();
            var result = _sut.TestValidate(request);
            result.ShouldNotHaveValidationErrorFor(p => p.CoordinateY);
        }

        [Fact]
        public void Should_have_error_when_coordinateX_is_negative()
        {
            var request = _requestBuilder.CoordinateX(-6).Build();
            var result = _sut.TestValidate(request);
            result.ShouldHaveValidationErrorFor(p => p.CoordinateX);
        }

        [Fact]
        public void Should_not_have_error_when_coordinateX_is_positive()
        {
            var request = _requestBuilder.Build();
            var result = _sut.TestValidate(request);
            result.ShouldNotHaveValidationErrorFor(p => p.CoordinateX);
        }
    }
}
