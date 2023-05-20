using PointsOfInterestByGps.Models;

namespace PointsOfInterestByGps.Repositories
{
    public interface IPoinsLocaleCoordinateRepository
    {
        PointsLocaleCoordinatesModel Create(PointsLocaleCoordinatesModel model);
        List<PointsLocaleCoordinatesModel> GetAllPoints();
    }
}
