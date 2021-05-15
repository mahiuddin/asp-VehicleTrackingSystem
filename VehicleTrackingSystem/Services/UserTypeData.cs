using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.DataAccess.Data;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public class UserTypeData : IUserTypeData
    {
        private AppDbContext _appDbContext;

        public UserTypeData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public UserType AddUserType(UserType userType)
        {
            _appDbContext.UserType.Add(userType);
            _appDbContext.SaveChanges();
            return userType;
        }

        public void DeleteUserType(UserType userType)
        {
            throw new NotImplementedException();
        }

        public UserType EditUserType(UserType userType)
        {
            throw new NotImplementedException();
        }

        public UserType GetUsertype(int id)
        {
            var userType = _appDbContext.UserType.Find(id);

            return userType;
        }

        public List<UserType> GetUserTypes()
        {
            return _appDbContext.UserType.ToList();
        }
    }
}
