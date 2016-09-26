using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartAngle.Data.Entities
{
    public class Variable
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double MinValue { get; set; }
        public double MaxValue{ get; set; }
    }
}
