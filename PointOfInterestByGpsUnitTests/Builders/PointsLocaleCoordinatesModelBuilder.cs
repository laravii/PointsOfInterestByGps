using Bogus;
using PointsOfInterestByGps.Models;

namespace PointOfInterestByGpsUnitTests.Builders
{
    internal class PointsLocaleCoordinatesModelBuilder : BaseBuilder<PointsLocaleCoordinatesModel>
    {
        public override PointsLocaleCoordinatesModel CreateObject() =>
            new Faker<PointsLocaleCoordinatesModel>()
                .RuleFor(s => s.CoordinateX, f => f.Random.Int(1, 100000))
                .RuleFor(s => s.CoordinateY, f => f.Random.Int(1, 100000))
                .RuleFor(s => s.PointDescription, f => f.Lorem.Word());
    }
}
