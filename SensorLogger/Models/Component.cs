using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class Component
    {
        [Key]
        public int ComponentID { get; set; }
        public string ComponentName { get; set; }

        public int NumberOfPins { get; set; }
    }
}
