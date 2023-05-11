using Bogus;
using PointsOfInterestByGps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfInterestByGpsUnitTests.Builders
{
    internal class CalculateDistanceModelBuilder : BaseBuilder<CalculateDistanceModel>
    {
        public override CalculateDistanceModel CreateObject() =>
            new Faker<CalculateDistanceModel>()
                .RuleFor(s => s.ReceivedCoordinateX, f => f.Random.Int(1, 100000))
                .RuleFor(s => s.ReceivedCoordinateY, f => f.Random.Int(1, 100000))
                .RuleFor(s => s.FoundCoordinateX, f => f.Random.Int(1, 100000))
                .RuleFor(s => s.FoundCoordinateY, f => f.Random.Int(1, 100000));
    }
}
