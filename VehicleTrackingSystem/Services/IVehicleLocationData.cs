using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public interface IVehicleLocationData
    {
        List<Location> GetLocations();
        Location GetLocation(int id);
        Location AddLocation(Location location);

        void DeleteLocation(Location location);

        Location EditLocation(Location location);
    }
}
