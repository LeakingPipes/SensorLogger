using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class ChartItemModel
    {
        public float Value { get; set; }
        public string ValueType { get; set; }
        public DateTime? Date_time { get; set; }
    }
}
