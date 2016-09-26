using SmartAngle.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAngle.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Device> DeviceRepository { get; }
        IRepository<DeviceType> DeviceTypeRepository { get; }
        IRepository<Variable> VariableRepository { get; }
        IRepository<Register> RegisterRepository { get; }

        void Save();
    }
}
