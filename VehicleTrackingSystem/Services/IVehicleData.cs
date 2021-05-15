using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public interface IVehicleData
    {
        List<Vehicle> GetVehicles();
        Vehicle GetVehicle(int id);
        Vehicle AddVehicle(Vehicle vehicle);

        void DeleteVehicle(Vehicle vehicle);

        Vehicle EditVehicle(Vehicle vehicle);
    }
}
