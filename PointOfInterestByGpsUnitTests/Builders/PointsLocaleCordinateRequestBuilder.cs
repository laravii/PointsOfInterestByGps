using Bogus;
using PointsOfInterestByGps.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfInterestByGpsUnitTests.Builders
{
    internal class PointsLocaleCordinateRequestBuilder : BaseBuilder<PointsLocaleCordinateRequest>
    {
        private string _description;
        private int _coordinateX;
        private int _coordinateY;

        public PointsLocaleCordinateRequestBuilder()
        {
            _description = Faker.Lorem.Word();
            _coordinateX = Faker.Random.Int(1, 100000);
            _coordinateY = Faker.Random.Int(1, 100000);
        }
        public override PointsLocaleCordinateRequest Build() => new() 
            { 
                PointDescription = _description, 
                CoordinateX = _coordinateX, 
                CoordinateY = _coordinateY 
            };

        public PointsLocaleCordinateRequestBuilder Description(string description)
        {
            _description = description;
            return this;
        }

        public PointsLocaleCordinateRequestBuilder CoordinateX(int coordinateX)
        {
            _coordinateX = coordinateX;
            return this;
        }

        public PointsLocaleCordinateRequestBuilder CoordinateY(int coordinateY)
        {
            _coordinateY = coordinateY;
            return this;
        }
    }
}
