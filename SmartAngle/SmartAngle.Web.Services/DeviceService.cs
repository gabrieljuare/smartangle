using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAngle.Data.Entities;
using SmartAngle.Data.Repository;

namespace SmartAngle.Web.Services
{
    public class DeviceService : IDeviceService
    {
        private IUnitOfWork unitOfWork;
        public DeviceService()
        {
            unitOfWork = new UnitOfWork();
        }

        public Guid AddDevice(Guid userId, Device deviceToAdd)
        {
            deviceToAdd.Id = Guid.NewGuid();
            deviceToAdd.UserId = userId;
            unitOfWork.DeviceRepository.Insert(deviceToAdd);
            return deviceToAdd.Id;
        }

        public void DeleteDevice(Guid deviceId)
        {
            Device deviceToDelete = unitOfWork.DeviceRepository.GetByID(deviceId);
            unitOfWork.DeviceRepository.Delete(deviceToDelete);
        }

        public List<Device> GetAllDevices(Guid id)
        {
            return unitOfWork.UserRepository.GetByID(id).Devices;
        }

        public Device GetDevice(Guid id)
        {
            return unitOfWork.DeviceRepository.GetByID(id);
        }

        public void UpdateDevice(Guid deviceId, Device deviceToUpdate)
        {
            //TODO: Validations
            unitOfWork.DeviceRepository.Update(deviceToUpdate);
        }
    }
}
