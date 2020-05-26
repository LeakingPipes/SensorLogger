using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Data;
using SensorLogger.Models;

namespace SensorLogger.Controllers
{
    public class HardwareController : Controller
    {
        private readonly SensorLoggerContext _context;

        public HardwareController(SensorLoggerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var _boards = await _context.Boards
                .AsNoTracking().ToListAsync();

            var _components = await _context.Components
                .AsNoTracking().ToListAsync();

            //IEnumerable<HardwareModel> hardware
            HardwareModel hardware = new HardwareModel { boards = _boards, components = _components };

            return View(hardware);
        }

        public async Task<IActionResult> CreateBoard()
        {
            IEnumerable<Board> boards = await _context.Boards.AsNoTracking().ToListAsync();
            //HardwareModel hardware = new HardwareModel { boards = _boards, components = _components };

            return View(boards);
        }

        public async Task<IActionResult> CreateComponent()
        {
            IEnumerable<Component> components = await _context.Components.AsNoTracking().ToListAsync();
            //HardwareModel hardware = new HardwareModel { boards = _boards, components = _components };

            return View(components);
        }
    }
}