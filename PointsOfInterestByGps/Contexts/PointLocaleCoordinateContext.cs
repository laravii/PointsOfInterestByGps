using Microsoft.EntityFrameworkCore;
using PointsOfInterestByGps.Models;

namespace PointsOfInterestByGps.Contexts
{
    public class PointLocaleCoordinateContext : DbContext
    {
        public PointLocaleCoordinateContext(DbContextOptions<PointLocaleCoordinateContext> options) : base(options)
        {
        }
        public DbSet<PointsLocaleCoordinatesModel> PointsLocaleCoordinates { get; set; }
    }
}
