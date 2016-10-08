using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAngle.Data.Entities
{
    public class Device
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual DeviceType DeviceType { get; set; } 
        public virtual List<Register> Registers { get; set; }

        public Device()
        {
            Id = Guid.NewGuid();
            Registers = new List<Register>();
        }
    }
}
