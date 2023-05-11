using PointsOfInterestByGps.Models;

namespace PointsOfInterestByGps.Repositories
{
    public interface IPoinsLocaleCoordinateRepository
    {
        public PointsLocaleCoordinatesModel Create(PointsLocaleCoordinatesModel model);
        public List<PointsLocaleCoordinatesModel> GetAllPoints();
    }
}
