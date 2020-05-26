using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class BoardComponent
    {
        [Key]
        public int ComponentID { get; set; }
        public string ComponentName { get; set; }

        public virtual ICollection<WireConnection> WireConnections { get; set; }

        [ForeignKey("BoardID")]
        public int BoardID { get; set; }
    }
}
