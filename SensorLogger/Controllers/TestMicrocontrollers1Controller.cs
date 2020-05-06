using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Data;
using SensorLogger.Models;

namespace SensorLogger.Controllers
{
    public class TestMicrocontrollers1Controller : Controller
    {
        private readonly SensorLoggerContext _context;

        public TestMicrocontrollers1Controller(SensorLoggerContext context)
        {
            _context = context;
        }

        // GET: TestMicrocontrollers1
        public async Task<IActionResult> Index()
        {
            var sensorLoggerContext = _context.Microcontrollers.Include(m => m.User);
            return View(await sensorLoggerContext.ToListAsync());
        }

        // GET: TestMicrocontrollers1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microcontroller = await _context.Microcontrollers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MicrocontrollerID == id);
            if (microcontroller == null)
            {
                return NotFound();
            }

            return View(microcontroller);
        }

        // GET: TestMicrocontrollers1/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID");
            return View();
        }

        // POST: TestMicrocontrollers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MicrocontrollerID,MicrocontrollerName,isPrivate,UserID")] Microcontroller microcontroller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(microcontroller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", microcontroller.UserID);
            return View(microcontroller);
        }

        // GET: TestMicrocontrollers1/Edit/5
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", microcontroller.UserID);
            return View(microcontroller);
        }

        // POST: TestMicrocontrollers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MicrocontrollerID,MicrocontrollerName,isPrivate,UserID")] Microcontroller microcontroller)
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", microcontroller.UserID);
            return View(microcontroller);
        }

        // GET: TestMicrocontrollers1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microcontroller = await _context.Microcontrollers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MicrocontrollerID == id);
            if (microcontroller == null)
            {
                return NotFound();
            }

            return View(microcontroller);
        }

        // POST: TestMicrocontrollers1/Delete/5
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
