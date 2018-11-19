using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceMonitor.Models;

    public class AttendanceMonitorContext : DbContext
    {
        public AttendanceMonitorContext (DbContextOptions<AttendanceMonitorContext> options)
            : base(options)
        {
        }

        public DbSet<AttendanceMonitor.Models.AttendanceItem> AttendanceItem { get; set; }
    }
