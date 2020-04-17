using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class ReadingValue
    {
        [Key]
        public int ReadingValueID { get; set; }
        [DisplayFormat(NullDisplayText = "")]
        public float Value { get; set; }
        [DisplayFormat(NullDisplayText = "")]
        public string ValueType { get; set; }
        [ForeignKey("ReadingID")]
        public int ReadingID { get; set; }
        public virtual Reading Readings { get; set; }
    }
}
