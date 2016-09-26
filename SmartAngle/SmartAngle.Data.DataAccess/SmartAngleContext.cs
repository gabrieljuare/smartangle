using SmartAngle.Data.Entities;
using System.Data.Entity;

namespace SmartAngle.Data.DataAccess
{
    public class SmartAngleContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }


    }
}
