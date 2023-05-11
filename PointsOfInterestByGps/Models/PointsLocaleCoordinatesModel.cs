using System.ComponentModel.DataAnnotations;

namespace PointsOfInterestByGps.Models
{
    public class PointsLocaleCoordinatesModel
    {
        public PointsLocaleCoordinatesModel(string pointDescription, int coordinateX, int coordinateY)
        {
            PointDescription = pointDescription;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
     
        [Key]
        public int Id { get; set; }
        [Required]
        public string PointDescription { get; set; }
        [Required]
        public int CoordinateX { get; set; }
        [Required]
        public int CoordinateY { get; set; }
    }
}
