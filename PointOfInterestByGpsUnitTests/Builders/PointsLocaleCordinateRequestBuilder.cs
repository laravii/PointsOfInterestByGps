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
        public override PointsLocaleCordinateRequest Build() => CreateRequest();

        private PointsLocaleCordinateRequest CreateRequest() =>
            new Faker<PointsLocaleCordinateRequest>()
                .RuleFor(s => s.CoordinateX, f => f.Random.Int(1, 100000))
                .RuleFor(s => s.CoordinateY, f => f.Random.Int(1, 100000))
                .RuleFor(s => s.PointDescription, f => f.Lorem.Word());
    }
}
