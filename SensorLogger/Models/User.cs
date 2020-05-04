﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public virtual ICollection<Microcontroller> Microcontrollers { get; set; }
    }
}