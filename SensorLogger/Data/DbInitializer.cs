using SensorLogger.Models;
using System;
using System.Linq;

namespace SensorLogger.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SensorLoggerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Microcontrollers.Any())
            {
                return;   // DB has been seeded
            }

            var microcontrollers = new Microcontroller[]
            {
            new Microcontroller{MicrocontrollerName="Controller 1 med temperatur og fugtmaaler"},
            new Microcontroller{MicrocontrollerName="Controller 2 med temperaturmaaler"},
            new Microcontroller{MicrocontrollerName="Controller 3 med lysmaaler"}
            };
            foreach (Microcontroller s in microcontrollers)
            {
                context.Microcontrollers.Add(s);
            }
            //context.SaveChanges();

            var readings = new Reading[]
            {
            new Reading{MicrocontrollerID=1, ReadingID=1, Date_time=DateTime.Parse("2020-09-01 7:24:37")},
            new Reading{MicrocontrollerID=2, ReadingID=2, Date_time=DateTime.Parse("2020-12-03 9:11:42")},
            new Reading{MicrocontrollerID=2, ReadingID=3, Date_time=DateTime.Parse("2020-01-11 1:53:26")},
            new Reading{MicrocontrollerID=3, ReadingID=4, Date_time=DateTime.Parse("2020-11-03 3:36:51")},
            new Reading{MicrocontrollerID=3, ReadingID=5, Date_time=DateTime.Parse("2020-03-02 8:34:12")}
            };
            foreach (Reading c in readings)
            {
                context.Readings.Add(c);
            }
            //context.SaveChanges();

            var readingValues = new ReadingValue[]
            {
            new ReadingValue{ReadingValueID=1, ReadingID=1, Value=23, ValueType="C"},
            new ReadingValue{ReadingValueID=2, ReadingID=1, Value=67, ValueType="Procent"},

            new ReadingValue{ReadingValueID=3, ReadingID=2, Value=25, ValueType="C"},

            new ReadingValue{ReadingValueID=4, ReadingID=3, Value=21, ValueType="C"},

            new ReadingValue{ReadingValueID=5, ReadingID=4, Value=1032, ValueType="LUX"},

            new ReadingValue{ReadingValueID=6, ReadingID=5, Value=21032, ValueType="LUX"}
            };
            foreach (ReadingValue e in readingValues)
            {
                context.ReadingValues.Add(e);
            }
            //context.SaveChanges();
        }
    }
}