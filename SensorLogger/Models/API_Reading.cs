using SensorLogger.Models;
using System.Collections.Generic;

public class API_Reading
{
    public int MicrocontrollerID { get; set; }
    public virtual ICollection<ReadingValue> ReadingValues { get; set; }
}