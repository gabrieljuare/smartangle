using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAngle.Data.Entities
{
    public class Register
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public virtual Variable Variable { get; set; }
        public DateTime DateOfMeasure { get; set; }

    }
}
