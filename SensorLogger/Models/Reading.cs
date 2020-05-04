using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class Reading
    {
        [Key]
        public int ReadingID { get; set; }
        [DisplayFormat(NullDisplayText = "No update")]
        public DateTime Date_time { get; set; }

        [ForeignKey("MicrocontrollerID")]
        public int MicrocontrollerID { get; set; }
        public virtual Microcontroller Microcontroller { get; set; }

        public virtual ICollection<ReadingValue> ReadingValues { get; set; }
    }
}
