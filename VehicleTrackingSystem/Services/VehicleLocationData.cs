using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.DataAccess.Data;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public class VehicleLocationData : IVehicleLocationData
    {
        private AppDbContext _appDbContext;

        public VehicleLocationData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Location AddLocation(Location location)
        {
            location.CreatedTime = DateTime.Now;
            _appDbContext.Location.Add(location);
            _appDbContext.SaveChanges();
            return location;
        }

        public void DeleteLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Location EditLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(int id)
        {
            var location = _appDbContext.Location.Find(id);

            return location;
        }

        public List<Location> GetLocations()
        {
            return _appDbContext.Location.ToList();
        }
    }
}
