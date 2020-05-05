using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorLogger.Models
{
    public enum Role
    {
        Admin, User
    }

    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public Role? Role { get; set; }

        public virtual ICollection<Microcontroller> Microcontrollers { get; set; }
    }
}