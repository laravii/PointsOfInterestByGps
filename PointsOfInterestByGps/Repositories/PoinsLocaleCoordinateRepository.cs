﻿using PointsOfInterestByGps.Contexts;
using PointsOfInterestByGps.Models;

namespace PointsOfInterestByGps.Repositories
{
    public class PoinsLocaleCoordinateRepository : IPoinsLocaleCoordinateRepository
    {
        private readonly PointLocaleCoordinateContext _context;

        public PoinsLocaleCoordinateRepository(PointLocaleCoordinateContext context)
        {
            _context = context;
        }

        public PointsLocaleCoordinatesModel Create(PointsLocaleCoordinatesModel model)
        {
            _context.PointsLocaleCoordinates.Add(model);
            _context.SaveChanges();
            return model;
        }

        public List<PointsLocaleCoordinatesModel> GetAllPoints()
        {
            var points = _context.PointsLocaleCoordinates;
            if(points == null) return new List<PointsLocaleCoordinatesModel>();
            return points.ToList();
        }
    }
}
