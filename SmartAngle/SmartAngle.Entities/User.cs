using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAngle.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public virtual List<Device> Dispositivos { get; set; }
    }
}
