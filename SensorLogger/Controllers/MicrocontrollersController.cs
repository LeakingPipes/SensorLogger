using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Data;
using SensorLogger.Models;
using System.Security.Claims;

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
                .Include(r => r.User)
            .Include(s => s.Readings)
                .ThenInclude(e => e.ReadingValues)
            .AsNoTracking().ToListAsync();

            int userid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            List<Microcontroller> tempMicrocontroller = new List<Microcontroller>();

            foreach (Microcontroller _microcontroller in microcontrollers)
            {
                if (!_microcontroller.isPrivate || userid == _microcontroller.UserID)
                {
                    tempMicrocontroller.Add(_microcontroller);
                }
            }

            return View(tempMicrocontroller);
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
            int userid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            microcontroller.UserID = userid;

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

            string role = this.User.FindFirstValue(ClaimTypes.Role);
            int userid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (role != Role.Admin.ToString() && userid != microcontroller.UserID)
            {
                return Unauthorized();
            }

            if (microcontroller == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Name", microcontroller.UserID);
            return View(microcontroller);
        }

        // POST: Microcontrollers/Edit/5
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Name", microcontroller.UserID);
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
