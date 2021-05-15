using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.DataAccess.Data;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public class VehicleData : IVehicleData
    {
        private AppDbContext _appDbContext;

        public VehicleData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Vehicle AddVehicle(Vehicle vehicle)
        {
            _appDbContext.Vehicle.Add(vehicle);
            _appDbContext.SaveChanges();
            return vehicle;
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle EditVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
