using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceSystem.Models;

namespace StudentAttendanceSystem.Data
{
    public class StudentAttendanceSystemContext : DbContext
    {
        public StudentAttendanceSystemContext (DbContextOptions<StudentAttendanceSystemContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAttendanceSystem.Models.AttendanceRecord> AttendanceRecord { get; set; } = default!;
    }
}
