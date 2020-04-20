using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class Microcontroller
    {
        [Key]
        public int MicrocontrollerID { get; set; }
        public string MicrocontrollerName { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Reading> Readings { get; set; }
    }
}
