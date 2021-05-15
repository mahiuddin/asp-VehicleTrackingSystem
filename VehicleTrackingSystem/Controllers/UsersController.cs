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
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private IUserData _userData;
        public UsersController(IUserData userData)
        {
            _userData = userData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetUsers()
        {
            return Ok(_userData.GetUsers());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userData.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"user with id: {id} was not found");
        }

        [HttpPost]
        [Authorize]
        [Route("api/[controller]")]
        public IActionResult GetUser(User user)
        {
            _userData.AddUser(user);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.UserId, user);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userData.GetUser(id);

            if (user != null)
            {
                _userData.DeleteUser(user);
                return Ok();
            }

            return NotFound($"user with id: {id} was not found");
        }
    }
}
