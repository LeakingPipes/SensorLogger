using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class Microcontroller
    {
        public int MicrocontrollerID { get; set; }
        public string MicrocontrollerName { get; set; }

        public virtual ICollection<Reading> Readings { get; set; }
    }
}
