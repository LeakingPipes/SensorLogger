using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Data;
using SensorLogger.Models;

namespace SensorLogger.Controllers.API
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private readonly SensorLoggerContext _context;

        public ReadingsController(SensorLoggerContext context)
        {
            _context = context;
        }

        // GET: api/Readings
        [HttpGet("{id}")]
        public async Task<Microcontroller> GetAsync(int id, string authKey)
        {
            Microcontroller microcontroller = await _context.Microcontrollers
                .AsNoTracking()
                .Include(s => s.Readings)
                .ThenInclude(s => s.ReadingValues)
                .FirstOrDefaultAsync(m => m.MicrocontrollerID == id);

            if (authKey == microcontroller.APIauthKey)
            {
                return microcontroller;
            }

            return null;
        }

        // POST: api/Readings
        [HttpPost("{id}")]
        public async Task<ActionResult<Reading>> PostReading(int ID, string authKey, [FromBody]Reading reading)
        {
            Microcontroller microcontroller = await _context.Microcontrollers
                            .AsNoTracking()
                            .Include(s => s.Readings)
                            .FirstOrDefaultAsync(m => m.MicrocontrollerID == ID);

            Reading _reading = new Reading { Date_time = DateTime.Now, MicrocontrollerID = ID, Microcontroller = microcontroller, ReadingValues = reading.ReadingValues };

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
                if (ReadingExists(ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            if (authKey == microcontroller.APIauthKey)
            {
                return CreatedAtAction("GetReading", new { id = ID }, reading);
            }

            return null;
        }

        private bool ReadingExists(int id)
        {
            return _context.Readings.Any(e => e.ReadingID == id);
        }
    }
}
