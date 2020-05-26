using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class WireConnection
    {
        [Key]
        public int ConnectionID { get; set; }
        public string ConnectionName { get; set; }

        public string BoardPinName { get; set; }
        public int BoardPinNumber { get; set; }

        public string ComponentPinName { get; set; }
        public int ComponentPinNumber { get; set; }

        [ForeignKey("ComponentID")]
        public int ComponentID { get; set; }
    }
}