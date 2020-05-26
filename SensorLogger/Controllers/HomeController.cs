using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Data;
using SensorLogger.Models;

namespace SensorLogger.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly SensorLoggerContext _context;

        public HomeController(SensorLoggerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();
            var microcontrollers = await _context.Microcontrollers.AsNoTracking().ToListAsync();
            var readings = await _context.Readings.AsNoTracking().ToListAsync();

            int userNum = users.Count;
            int microcontrollerNum = microcontrollers.Count;
            int readingNum = readings.Count;

            HomeModel homeModel = new HomeModel
            {
                numberOfUsers = userNum,
                numberOfMicrocontrollers = microcontrollerNum,
                numberOfReadings = readingNum
            };

            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
