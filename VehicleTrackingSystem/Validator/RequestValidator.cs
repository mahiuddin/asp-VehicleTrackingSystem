using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Services;

namespace VehicleTrackingSystem.Validator
{
    public class RequestValidator
    {
        private IVehicleData _vehicleData;
        public bool IsPermittedToEditVehicle(string userId, int vehicleId)
        {
            var user = _vehicleData.GetVehicle(vehicleId);
            if (user == null) return false;
            if (userId == user.UserId.ToString()) return true;
            return false;
        }
    }
}