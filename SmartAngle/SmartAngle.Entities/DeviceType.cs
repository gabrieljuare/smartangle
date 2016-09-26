using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAngle.Data.Entities
{
    public class DeviceType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public virtual List<Variable> Variables { get; set; }
    }
}
