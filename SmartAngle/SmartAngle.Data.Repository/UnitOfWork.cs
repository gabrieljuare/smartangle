using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAngle.Data.Entities;
using SmartAngle.Data.DataAccess;

namespace SmartAngle.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private SmartAngleContext context;
        private GenericRepository<User> userRepository;
        private GenericRepository<Device> deviceRepository;
        private GenericRepository<DeviceType> deviceTypeRepository;
        private GenericRepository<Variable> variableRepository;
        private GenericRepository<Register> registerRepository;

        private bool disposed = false;

        public UnitOfWork(SmartAngleContext context)
        {
            this.context = context;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return this.userRepository;
            }
        }

        public IRepository<Device> DeviceRepository
        {
            get
            {
                if (this.deviceRepository == null)
                {
                    this.deviceRepository = new GenericRepository<Device>(this.context);
                }
                return this.deviceRepository;
            }
        }

        public IRepository<DeviceType> DeviceTypeRepository
        {
            get
            {
                if (this.deviceTypeRepository == null)
                {
                    this.deviceTypeRepository = new GenericRepository<DeviceType>(this.context);
                }
                return this.deviceTypeRepository;
            }
        }

        public IRepository<Variable> VariableRepository
        {
            get
            {
                if (this.variableRepository == null)
                {
                    this.variableRepository = new GenericRepository<Variable>(this.context);
                }
                return this.variableRepository;
            }
        }

        public IRepository<Register> RegisterRepository
        {
            get
            {
                if (this.registerRepository == null)
                {
                    this.registerRepository = new GenericRepository<Register>(this.context);
                }
                return this.registerRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}