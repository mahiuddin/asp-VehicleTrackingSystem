using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public interface IUserData
    {
        List<User> GetUsers();
        User GetUser(int id);
        User AddUser(User user);

        void DeleteUser(User user);

        User EditUser(User user);
    }
}
