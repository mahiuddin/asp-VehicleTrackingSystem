using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public interface IUserTypeData
    {
        List<UserType> GetUserTypes();
        UserType GetUsertype(int id);
        UserType AddUserType(UserType userType);

        void DeleteUserType(UserType userType);

        UserType EditUserType(UserType userType);
    }
}
