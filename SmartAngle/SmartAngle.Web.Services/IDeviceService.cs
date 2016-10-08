using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAngle.Data.Entities;

namespace SmartAngle.Web.Services
{
    public interface IDeviceService
    {
        List<Device> GetAllDevices(Guid id);
        Device GetDevice(Guid id);
        Guid AddDevice(Guid id, Device deviceToAdd);
        void UpdateDevice(Guid deviceId, Device deviceToUpdate);
        void DeleteDevice(Guid deviceId);
    }
}
