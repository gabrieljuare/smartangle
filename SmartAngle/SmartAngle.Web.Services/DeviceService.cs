using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAngle.Data.Entities;

namespace SmartAngle.Web.Services
{
    public class DeviceService : IDeviceService
    {
        public DeviceService()
        {

        }

        public Guid AddDevice(Guid id, Device deviceToAdd)
        {
            throw new NotImplementedException();
        }

        public void DeleteDevice(Guid deviceId)
        {
            throw new NotImplementedException();
        }

        public List<Device> GetAllDevices(Guid id)
        {
            throw new NotImplementedException();
        }

        public Device GetDevice(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDevice(Guid deviceId, Device deviceToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
