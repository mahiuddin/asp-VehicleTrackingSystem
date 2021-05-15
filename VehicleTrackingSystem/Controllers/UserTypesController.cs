using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private IUserTypeData _userTypeData;
        public UserTypesController(IUserTypeData userTypeData)
        {
            _userTypeData = userTypeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetUserTypes()
        {
            return Ok(_userTypeData.GetUserTypes());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetUserType(int id)
        {
           // var userType = _userTypeData.GetUserType(id);
          //  if (userType != null)
          //  {
          //      return Ok(userType);
          //  }
            return NotFound($"userType with id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetUserType(UserType userType)
        {
            _userTypeData.AddUserType(userType);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + userType.UserTypeId, userType);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteUserType(int id)
        {
           // var userType = _userTypeData.GetUserType(id);

          //  if (userType != null)
          //  {
           //     _userTypeData.DeleteUserType(userType);
            //    return Ok();
          //  }

            return NotFound($"UserType with id: {id} was not found");
        }
    }
}
