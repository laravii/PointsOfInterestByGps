using Microsoft.AspNetCore.Mvc;
using PointsOfInterestByGps.Extension;
using PointsOfInterestByGps.Models;
using PointsOfInterestByGps.Repositories;
using PointsOfInterestByGps.Requests;
using PointsOfInterestByGps.Contexts;
using PointsOfInterestByGps.Validations;
using FluentValidation;

namespace PointsOfInterestByGps.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointsOfInterestController : Controller
    {
        private readonly IPoinsLocaleCoordinateRepository _repository;
        private readonly IValidator<PointsLocaleCordinateRequest> _validator;

        public PointsOfInterestController(IPoinsLocaleCoordinateRepository repository, IValidator<PointsLocaleCordinateRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        [HttpGet("/points")]
        public ActionResult<List<PointsLocaleCoordinatesModel>> GetAllPoints()
        {
            var points = _repository.GetAllPoints();

            return Ok(points);
        }


        [HttpGet("/points/by/distance/{coordinateX}/{coordinateY}/{maxDistance}")]
        public ActionResult<List<PointsLocaleCoordinatesModel>> GetNearPoints(int coordinateX, int coordinateY, int maxDistance = 10)
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
        public ActionResult<PointsLocaleCoordinatesModel> CreateNewPoint([FromBody] PointsLocaleCordinateRequest request)
        {
            var validatorResult = _validator.Validate(request);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }
            PointsLocaleCoordinatesModel model = new(request.PointDescription, request.CoordinateX, request.CoordinateY);
            var points = _repository.Create(model);
            return Ok(points);
        }
    }
}
