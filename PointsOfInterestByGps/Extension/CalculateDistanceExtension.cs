using PointsOfInterestByGps.Models;

namespace PointsOfInterestByGps.Extension
{
    public static class CalculateDistanceExtension
    {
        public static double CalculateDistance(CalculateDistanceModel model)
        {
            var pointX = Math.Pow((model.ReceivedCoordinateX - model.FoundCoordinateX), 2);
            var pointY = Math.Pow((model.ReceivedCoordinateY - model.ReceivedCoordinateY), 2);
            var distance = Math.Sqrt(pointX + pointY);

            return distance;
        }
    }
}
