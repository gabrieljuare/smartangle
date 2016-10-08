using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAngle.Data.Entities;

namespace SmartAngle.Web.Services
{
    public interface IDeviceTypeService
    {
        List<DeviceType> GetDeviceTypes();
        DeviceType GetDeviceType(Guid id);
    }
}
