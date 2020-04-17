using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Data;
using SensorLogger.Models;

namespace SensorLogger.Views.Microcontrollers
{
    public class MicrocontrollersController : Controller
    {
        private readonly SensorLoggerContext _context;

        public MicrocontrollersController(SensorLoggerContext context)
        {
            _context = context;
        }

        // GET: Microcontrollers
        public async Task<IActionResult> Index()
        {
            var microcontrollers = await _context.Microcontrollers
            .Include(s => s.Readings)
                .ThenInclude(e => e.ReadingValues)
            .AsNoTracking().ToListAsync();

            return View(microcontrollers);
        }

        // GET: Microcontrollers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var microcontroller = await _context.Microcontrollers
            //    .FirstOrDefaultAsync(m => m.MicrocontrollerID == id);

            var microcontroller = await _context.Microcontrollers
                .Include(s => s.Readings)
                    .ThenInclude(e => e.ReadingValues)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MicrocontrollerID == id);

            if (microcontroller == null)
            {
                return NotFound();
            }

            return View(microcontroller);
        }

        // GET: Microcontrollers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Microcontrollers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MicrocontrollerID,MicrocontrollerName")] Microcontroller microcontroller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(microcontroller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(microcontroller);
        }

        // GET: Microcontrollers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microcontroller = await _context.Microcontrollers.FindAsync(id);
            if (microcontroller == null)
            {
                return NotFound();
            }
            return View(microcontroller);
        }

        // POST: Microcontrollers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MicrocontrollerID,MicrocontrollerName")] Microcontroller microcontroller)
        {
            if (id != microcontroller.MicrocontrollerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(microcontroller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MicrocontrollerExists(microcontroller.MicrocontrollerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(microcontroller);
        }

        // GET: Microcontrollers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microcontroller = await _context.Microcontrollers
                .FirstOrDefaultAsync(m => m.MicrocontrollerID == id);
            if (microcontroller == null)
            {
                return NotFound();
            }

            return View(microcontroller);
        }

        // POST: Microcontrollers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var microcontroller = await _context.Microcontrollers.FindAsync(id);
            _context.Microcontrollers.Remove(microcontroller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MicrocontrollerExists(int id)
        {
            return _context.Microcontrollers.Any(e => e.MicrocontrollerID == id);
        }
    }
}
