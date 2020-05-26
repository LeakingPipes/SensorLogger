using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class MicrocontrollerBoard
    {
        [Key]
        public int BoardID { get; set; }
        public string BoardName { get; set; }

        public virtual ICollection<BoardComponent> BoardComponents { get; set; }
    }
}
