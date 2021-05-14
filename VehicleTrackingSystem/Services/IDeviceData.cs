using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Model.Models;

namespace VehicleTrackingSystem.Services
{
    public interface IDeviceData
    {
        List<Device> GetDevices();
        Device GetDevice(int id);
        Device AddDevice(Device device);

        void DeleteDevice(Device device);

        Device EditDevice(Device device);

    }
}
