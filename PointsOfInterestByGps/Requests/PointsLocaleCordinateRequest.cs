namespace PointsOfInterestByGps.Requests
{
    public record PointsLocaleCordinateRequest
    {
        public string PointDescription { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }
}
