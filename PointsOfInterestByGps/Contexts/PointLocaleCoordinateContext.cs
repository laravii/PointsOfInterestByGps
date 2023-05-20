using Microsoft.EntityFrameworkCore;
using PointsOfInterestByGps.Models;

namespace PointsOfInterestByGps.Contexts
{
    public class PointLocaleCoordinateContext : DbContext
    {
        public DbSet<PointsLocaleCoordinatesModel> PointsLocaleCoordinates { get; }
    }
}
