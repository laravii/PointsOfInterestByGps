using Microsoft.AspNetCore.Mvc;
using PointsOfInterestByGps.Extension;
using PointsOfInterestByGps.Models;
using PointsOfInterestByGps.Repositories;
using PointsOfInterestByGps.Requests;
using PointsOfInterestByGps.Contexts;

namespace PointsOfInterestByGps.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointsOfInterestController : Controller
    {
        private readonly IPoinsLocaleCoordinateRepository _repository;

        public PointsOfInterestController(IPoinsLocaleCoordinateRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/points")]
        public IActionResult GetAllPoints()
        {
            var points = _repository.GetAllPoints();

            return Ok(points);
        }


        [HttpGet("/points/by/distance/{coordinateX}/{coordinateY}/{maxDistance}")]
        public IActionResult GetNearPoints(int coordinateX, int coordinateY, int maxDistance = 10)
        {
            var points = _repository.GetAllPoints();
            List<PointsLocaleCoordinatesModel> nearPoints = new();

            foreach (var item in points)
            {
                var pointDistance = CalculateDistanceExtension.CalculateDistance(
                    new CalculateDistanceModel() 
                    { 
                        ReceivedCoordinateX = coordinateX,
                        ReceivedCoordinateY = coordinateY,
                        FoundCoordinateX = item.CoordinateX,
                        FoundCoordinateY = item.CoordinateY
                    });

                if(pointDistance <= maxDistance)
                {
                    nearPoints.Add(item);
                }
            }

            return Ok(nearPoints);
        }

        [HttpPost("/points/create")]
        public IActionResult Post([FromBody] PointsLocaleCordinateRequest request)
        {
            PointsLocaleCoordinatesModel model = new(request.PointDescription, request.CoordinateX, request.CoordinateY);
            var points = _repository.Create(model);
            return Ok(points);
        }
    }
}
