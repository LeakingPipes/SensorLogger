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
using System.Security.Cryptography;

namespace SensorLogger.Views.Microcontrollers
{
    public class MicrocontrollersController : Controller
    {
        private readonly SensorLoggerContext _context;
        private readonly IHashData hashData;

        public MicrocontrollersController(SensorLoggerContext context, IHashData hashData)
        {
            _context = context;
            this.hashData = hashData;
        }

        // GET: Microcontrollers
        public async Task<IActionResult> Index(string sortOrder)
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
            

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.OwnerSortParm = sortOrder == "Owner" ? "owner_desc" : "Owner";
            ViewBag.PrivateSortParm = sortOrder == "Private" ? "private_desc" : "Private";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            
            IEnumerable<Microcontroller> sort_microcontrollers = from s in tempMicrocontroller
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    sort_microcontrollers = sort_microcontrollers.OrderByDescending(s => s.MicrocontrollerName);
                    break;
                case "Owner":
                    sort_microcontrollers = sort_microcontrollers.OrderBy(s => s.User.Name);
                    break;
                case "owner_desc":
                    sort_microcontrollers = sort_microcontrollers.OrderByDescending(s => s.User.Name);
                    break;
                case "Private":
                    sort_microcontrollers = sort_microcontrollers.OrderBy(s => s.isPrivate);
                    break;
                case "private_desc":
                    sort_microcontrollers = sort_microcontrollers.OrderByDescending(s => s.isPrivate);
                    break;
                    //Denne dele er ikke særligt godt lavet men det virker, jeg ender nok med at lave det om.
                case "Date":
                    List<Microcontroller> _sort_microcontrollers1 = new List<Microcontroller>();
                    List<Microcontroller> null_sort_microcontrollers1 = new List<Microcontroller>();
                    foreach (Microcontroller microcontroller in sort_microcontrollers)
                    {
                        if(microcontroller.Readings.LastOrDefault<Reading>() != null)
                        {
                            _sort_microcontrollers1.Add(microcontroller);
                        }
                        else
                        {
                            null_sort_microcontrollers1.Add(microcontroller);
                        }
                    }
                    sort_microcontrollers = _sort_microcontrollers1;
                    sort_microcontrollers = sort_microcontrollers.OrderBy(s => s.Readings.LastOrDefault<Reading>().Date_time);
                    _sort_microcontrollers1 = sort_microcontrollers.ToList();
                    _sort_microcontrollers1.AddRange(null_sort_microcontrollers1);
                    sort_microcontrollers = _sort_microcontrollers1;
                    break;
                case "date_desc":
                    List<Microcontroller> _sort_microcontrollers2 = new List<Microcontroller>();
                    List<Microcontroller> null_sort_microcontrollers2 = new List<Microcontroller>();
                    foreach (Microcontroller microcontroller in sort_microcontrollers)
                    {
                        if (microcontroller.Readings.LastOrDefault<Reading>() != null)
                        {
                            _sort_microcontrollers2.Add(microcontroller);
                        }
                        else
                        {
                            null_sort_microcontrollers2.Add(microcontroller);
                        }
                    }
                    sort_microcontrollers = _sort_microcontrollers2;
                    sort_microcontrollers = sort_microcontrollers.OrderByDescending(s => s.Readings.LastOrDefault<Reading>().Date_time);
                    _sort_microcontrollers2 = sort_microcontrollers.ToList();
                    _sort_microcontrollers2.AddRange(null_sort_microcontrollers2);
                    sort_microcontrollers = _sort_microcontrollers2;
                    break;
                default:
                    sort_microcontrollers = sort_microcontrollers.OrderBy(s => s.MicrocontrollerName);
                    break;
            }

            return View(sort_microcontrollers);
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
            microcontroller.UserID = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] val = new byte[4];
                rng.GetBytes(val);

                int value = BitConverter.ToInt32(val, 0);

                string _AuthKey = hashData.ComputeHashSha512(value.ToString(), microcontroller.UserID.ToString());
                _AuthKey = _AuthKey.Substring(0, 12);
                microcontroller.APIauthKey = _AuthKey;
            }


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

            string role = this.User.FindFirstValue(ClaimTypes.Role);
            int userid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (role != Role.Admin.ToString() && userid != microcontroller.UserID)
            {
                return Unauthorized();
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

            string role = this.User.FindFirstValue(ClaimTypes.Role);
            int userid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (role != Role.Admin.ToString() && userid != microcontroller.UserID)
            {
                return Unauthorized();
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

            string role = this.User.FindFirstValue(ClaimTypes.Role);
            int userid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (role != Role.Admin.ToString() && userid != microcontroller.UserID)
            {
                return Unauthorized();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Microcontrollers/Delete/5
        public async Task<IActionResult> DeleteReading(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reading = await _context.Readings
                .Include(r => r.ReadingValues)
                .FirstOrDefaultAsync(m => m.ReadingID == id);

            if (reading == null)
            {
                return NotFound();
            }

            string role = this.User.FindFirstValue(ClaimTypes.Role);
            int userid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (role != Role.Admin.ToString() && userid != reading.Microcontroller.UserID)
            {
                return Unauthorized();
            }

            return View(reading);
        }

        // POST: Microcontrollers/Delete/5
        [HttpPost, ActionName("DeleteReading")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReadingDeleteConfirmed(int id)
        {
            var reading = await _context.Readings.FindAsync(id);
            _context.Readings.Remove(reading);

            string role = this.User.FindFirstValue(ClaimTypes.Role);
            int userid = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (role != Role.Admin.ToString() && userid != reading.Microcontroller.UserID)
            {
                return Unauthorized();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool MicrocontrollerExists(int id)
        {
            return _context.Microcontrollers.Any(e => e.MicrocontrollerID == id);
        }
    }
}
