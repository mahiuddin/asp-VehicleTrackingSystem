using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.DataAccess.Data;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public class UserData : IUserData
    {
        private AppDbContext _appDbContext;

        public UserData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public User AddUser(User user)
        {
            var password = EncryptData("mahiuddin");
            user.Password = (string)password;
           // user.Password = "mahi";
            _appDbContext.User.Add(user);
            _appDbContext.SaveChanges();
            return user;
        }

        private object EncryptData(string v)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            var user = _appDbContext.User.Find(id);

            return user;
        }

        public List<User> GetUsers()
        {
            return _appDbContext.User.ToList();
        }
    }
}
