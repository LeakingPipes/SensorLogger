using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Data;
using SensorLogger.Models;

namespace SensorLogger.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private readonly SensorLoggerContext _context;

        public ReadingsController(SensorLoggerContext context)
        {
            _context = context;
        }

        // POST: api/Readings
        [HttpPost]
        public async Task<ActionResult<Reading>> PostReading([FromBody]Reading reading)
        {
            Microcontroller microcontroller = await _context.Microcontrollers
                            .AsNoTracking()
                            .Include(s => s.Readings)
                            .FirstOrDefaultAsync(m => m.MicrocontrollerID == reading.MicrocontrollerID);

            Reading _reading = new Reading { Date_time = DateTime.Now, MicrocontrollerID = reading.MicrocontrollerID, Microcontroller = microcontroller, ReadingValues = reading.ReadingValues };

            _reading.Microcontroller = microcontroller;

            microcontroller.Readings.Add(_reading);

            foreach (ReadingValue readingValue in _reading.ReadingValues)
            {
                _context.ReadingValues.Add(readingValue);
            }

            _context.Entry(microcontroller).State = EntityState.Modified;
            _context.Readings.Add(_reading);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReadingExists(reading.ReadingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReading", new { id = reading.ReadingID }, reading);
        }

        private bool ReadingExists(int id)
        {
            return _context.Readings.Any(e => e.ReadingID == id);
        }
    }
}
