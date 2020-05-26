﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SensorLogger.Data;

namespace SensorLogger.Controllers
{
    public class CodeGeneratorController : Controller
    {
        private readonly SensorLoggerContext _context;

        public CodeGeneratorController(SensorLoggerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}