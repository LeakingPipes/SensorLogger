using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class ChartItemHolderModel
    {
        public string ValueType { get; set; }
        public List<ChartItemModel> ChartItems{ get; set; }
    }
}