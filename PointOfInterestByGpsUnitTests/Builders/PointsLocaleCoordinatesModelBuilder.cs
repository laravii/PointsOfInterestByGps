using Bogus;
using PointsOfInterestByGps.Models;

namespace PointOfInterestByGpsUnitTests.Builders
{
    internal class PointsLocaleCoordinatesModelBuilder : BaseBuilder<PointsLocaleCoordinatesModel>
    {
        private string _description;
        private int _coordinateX;
        private int _coordinateY;

        public PointsLocaleCoordinatesModelBuilder()
        {
            _description = Faker.Lorem.Word();
            _coordinateX = Faker.Random.Int(1, 100000);
            _coordinateY = Faker.Random.Int(1, 100000);
        }

        public override PointsLocaleCoordinatesModel Build() => new(_description, _coordinateX, _coordinateY);

        public PointsLocaleCoordinatesModelBuilder Description(string description)
        {
            _description = description;
            return this;
        }

        public PointsLocaleCoordinatesModelBuilder Coordinates(int coordinateX, int coordinateY)
        {
            _coordinateX = coordinateX;
            _coordinateY = coordinateY;
            return this;
        }
    }
}
