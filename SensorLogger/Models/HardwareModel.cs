using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class HardwareModel
    {
        public List<Board> boards { get; set; }
        public List<Component> components { get; set; }
    }
}
