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
    public class VehiclesController : ControllerBase
    {
        private IVehicleData _vehicleData;
        public VehiclesController(IVehicleData vehicleData)
        {
            _vehicleData = vehicleData;
        }

        [HttpPost]
        [Route("api/[controller]")]

       
        public IActionResult GetVehicle(Vehicle vehicle)
        {
            _vehicleData.AddVehicle(vehicle);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + vehicle.VehicleId, vehicle);
        }
    }
}
