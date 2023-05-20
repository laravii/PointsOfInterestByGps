using Bogus;

namespace PointOfInterestByGpsUnitTests.Builders
{
    internal abstract class BaseBuilder<T>
    {
        public Faker Faker = new("pt_BR");
        public abstract T Build();
    }
}
