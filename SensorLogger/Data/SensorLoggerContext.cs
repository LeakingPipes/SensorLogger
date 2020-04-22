﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SensorLogger.Models;
using Microsoft.EntityFrameworkCore;

namespace SensorLogger.Data
{
    public class SensorLoggerContext : DbContext
    {
        public SensorLoggerContext(DbContextOptions<SensorLoggerContext> options) : base(options)
        {
        }


        //public DbSet<User> Users { get; set; }
        public DbSet<Microcontroller> Microcontrollers { get; set; }
        public DbSet<Reading> Readings { get; set; }
        public DbSet<ReadingValue> ReadingValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Microcontroller>().ToTable("Microcontroller");
            modelBuilder.Entity<Reading>().ToTable("Reading");
            modelBuilder.Entity<ReadingValue>().ToTable("ReadingValue");
        }
    }
}
