using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.DataAccess.Data;
using VehicleTrackingSystem.Model.Models;
using VehicleTrackingSystem.Validator;

namespace VehicleTrackingSystem.Services
{
    public class DeviceData : IDeviceData
    {
        private AppDbContext _appDbContext;

        public DeviceData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private List<Device> devices = new List<Device>()
        {
            new Device()
            {
                DeviceId = 1,
                ImeiNumber = Guid.NewGuid(),
                Name = "Mobile",
                Status = true
            },
            new Device()
            {
                DeviceId = 2,
                ImeiNumber = Guid.NewGuid(),
                Name = "Mobile-2",
                Status = true
            },
            new Device()
            {
                DeviceId = 3,
                ImeiNumber = Guid.NewGuid(),
                Name = "Mobile-3",
                Status = true
            }
        };
        public Device AddDevice(Device device)
        {
            //device.DeviceId = 1;
            device.ImeiNumber = Guid.NewGuid();
            _appDbContext.Device.Add(device);
            _appDbContext.SaveChanges();
            //device.DeviceId = 4;
            //device.ImeiNumber = Guid.NewGuid();
            //devices.Add(device);
            return device;
            
        }

        public void DeleteDevice(Device device)
        {
            devices.Remove(device);
        }

        public Device EditDevice(Device device)
        {
            bool right = IsPermittedToEditVehicle("1", 23);
            throw new NotImplementedException();
        }

        private bool IsPermittedToEditVehicle(string v1, int v2)
        {
            throw new NotImplementedException();
        }

        public Device GetDevice(int id)
        {
            var device = _appDbContext.Device.Find(id);

            return device;   
        }

        public List<Device> GetDevices()
        {
            return _appDbContext.Device.ToList();
            //return devices;
        }
    }
}
