using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Auth;
using VehicleTrackingSystem.Model.Models;
using VehicleTrackingSystem.Services;

namespace VehicleTrackingSystem.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private IDeviceData _deviceData;
        public DevicesController(IDeviceData deviceData)
        {
            _deviceData = deviceData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetDevices() 
        {
            return Ok(_deviceData.GetDevices());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetDevice(int id)
        {
            var device = _deviceData.GetDevice(id);
            if(device != null)
            {
                return Ok(device);
            }
            return NotFound($"Device with id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetDevice(Device device)
        {
            _deviceData.AddDevice(device);
            
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + device.DeviceId, device);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteDevice(int id)
        {
            var device = _deviceData.GetDevice(id);

            if(device != null)
            {
                _deviceData.DeleteDevice(device);
                return Ok();
            }

            return NotFound($"Device with id: {id} was not found");
        }
    }
}
