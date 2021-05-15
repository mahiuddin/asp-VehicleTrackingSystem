using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Model.Models;
using VehicleTrackingSystem.Services;

namespace VehicleTrackingSystem.Controllers
{
    [ApiController]
    public class VehicleLocationsController : ControllerBase
    {
        private IVehicleLocationData _vehicleLocationData;
        public VehicleLocationsController(IVehicleLocationData vehicleLocationData)
        {
            _vehicleLocationData = vehicleLocationData;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetLocation(Location location)
        {
            _vehicleLocationData.AddLocation(location);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + location.LocationId, location);
        }
    }
}
